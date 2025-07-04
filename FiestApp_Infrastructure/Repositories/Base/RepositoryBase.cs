﻿using System.Linq.Expressions;
using FiestApp_Infrastructure.Documents.Base;
using FiestApp_Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FiestApp_Infrastructure.Repositories.Base;

public abstract class RepositoryBase<T>(DbContext context, ILogger<RepositoryBase<T>> logger) : IRepository<T>
    where T : DocumentBase
{
    private readonly DbContext _dbContext = context ?? throw new ArgumentNullException(nameof(context));
    private readonly DbSet<T> _dbSet = context.Set<T>();

    #region Read Operations

    public virtual async Task<PagedResult<T>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        foreach (var include in includes) query = query.Include(include);

        if (filter != null) query = query.Where(filter);

        var totalCount = await query.CountAsync(cancellationToken);

        if (orderBy != null) query = orderBy(query);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public virtual async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync([id], cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    [Obsolete("Better using GetPagedAsync when it's possible")]
    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.CountAsync(predicate, cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }

    public virtual async Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet.Select(selector).ToListAsync(cancellationToken);
    }

    #endregion

    #region Write Operations

    public virtual async Task<T?> InsertAsync(T doc, CancellationToken cancellationToken = default)
    {
        try
        {
            if (doc == null)
                throw new ArgumentNullException(nameof(doc));

            doc.CreatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            doc.UpdatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            await _dbSet.AddAsync(doc, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return await _dbSet.FindAsync([doc.Guid], cancellationToken);
        }
        catch (ArgumentNullException e)
        {
            RepoLogs.InsertAsyncError(logger, e);
            return null;
        }
    }

    public virtual async Task<IEnumerable<T>> InsertManyAsync(IEnumerable<T> docs,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (docs == null)
                throw new ArgumentNullException(nameof(docs));

            var documentBases = docs.ToList();
            foreach (var doc in documentBases)
            {
                doc.CreatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                doc.UpdatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            }

            var docList = documentBases.ToList();

            await _dbSet.AddRangeAsync(docList, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return docList;
        }
        catch (ArgumentNullException e)
        {
            RepoLogs.InsertManyAsyncError(logger, e);
            return [];
        }
    }

    public virtual async Task<T?> UpdateAsync(T doc, CancellationToken cancellationToken = default)
    {
        try
        {
            if (doc == null)
                throw new ArgumentNullException(nameof(doc));

            doc.CreatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            _dbSet.Update(doc);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return await _dbSet.FindAsync([doc.Guid], cancellationToken);
        }
        catch (ArgumentNullException e)
        {
            RepoLogs.UpdateAsyncError(logger, e);
            return null;
        }
    }

    public async Task PartialUpdateAsync<TPartial>(TPartial partialDoc,
        CancellationToken cancellationToken = default) where TPartial : T
    {
        try
        {
            var dbSet = _dbContext.Set<T>();

            var keyProperty = _dbContext.Model.FindEntityType(typeof(T))?
                .FindPrimaryKey()?.Properties.FirstOrDefault();

            if (keyProperty == null)
                throw new InvalidOperationException($"No primary key defined for {typeof(T).Name}");

            var doc = Activator.CreateInstance<T>();
            var keyPropInfo = typeof(T).GetProperty(keyProperty.Name);
            if (keyPropInfo == null)
                throw new InvalidOperationException(
                    $"Cannot find key property '{keyProperty.Name}' on {typeof(T).Name}");

            var convertedId = Convert.ChangeType(partialDoc.Guid, keyPropInfo.PropertyType);
            keyPropInfo.SetValue(doc, convertedId);

            dbSet.Attach(doc);
            var entry = _dbContext.Entry(doc);

            var partialProps = partialDoc.GetType().GetProperties();
            foreach (var prop in partialProps)
            {
                var targetProp = typeof(T).GetProperty(prop.Name);
                if (targetProp == null || prop.Name == keyProperty.Name)
                    continue;

                var value = prop.GetValue(partialDoc);
                if (value != null)
                {
                    targetProp.SetValue(doc, value);
                    entry.Property(prop.Name).IsModified = true;
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (InvalidOperationException e)
        {
            RepoLogs.PartialUpdateAsyncError(logger, e);
        }
    }

    public async Task PartialUpdateManyAsync<TPartial>(IEnumerable<TPartial> partialDocs,
        CancellationToken cancellationToken = default) where TPartial : T
    {
        try
        {
            var dbSet = _dbContext.Set<T>();

            var keyProperty = _dbContext.Model.FindEntityType(typeof(T))?
                .FindPrimaryKey()?.Properties.FirstOrDefault();

            if (keyProperty == null)
                throw new InvalidOperationException($"No primary key defined for {typeof(T).Name}");

            var keyPropName = keyProperty.Name;
            var keyPropInfo = typeof(T).GetProperty(keyPropName);

            if (keyPropInfo == null)
                throw new InvalidOperationException($"Cannot find key property '{keyPropName}' on {typeof(T).Name}");

            foreach (var partialDoc in partialDocs)
            {
                var doc = Activator.CreateInstance<T>();

                var partialKeyValue = typeof(TPartial).GetProperty(keyPropName)?.GetValue(partialDoc);
                if (partialKeyValue == null)
                    throw new InvalidOperationException($"Partial doc is missing key property '{keyPropName}'");

                var convertedId = Convert.ChangeType(partialKeyValue, keyPropInfo.PropertyType);
                keyPropInfo.SetValue(doc, convertedId);

                dbSet.Attach(doc);
                var entry = _dbContext.Entry(doc);

                var partialProps = partialDoc.GetType().GetProperties();
                foreach (var prop in partialProps)
                {
                    if (prop.Name == keyPropName)
                        continue;

                    var targetProp = typeof(T).GetProperty(prop.Name);
                    if (targetProp == null)
                        continue;

                    var value = prop.GetValue(partialDoc);
                    if (value != null)
                    {
                        targetProp.SetValue(doc, value);
                        entry.Property(prop.Name).IsModified = true;
                    }
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (InvalidOperationException e)
        {
            RepoLogs.PartialUpdateManyAsyncError(logger, e);
        }
    }


    public virtual async Task UpdateManyAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var docs = await _dbSet.Where(predicate).ToListAsync(cancellationToken);
            if (docs.Count != 0)
            {
                foreach (var doc in docs) doc.CreatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                _dbSet.UpdateRange(docs);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        catch (Exception e)
        {
            RepoLogs.UpdateManyAsyncError(logger, e);
        }
    }

    public virtual async Task DeleteAsync(T doc, CancellationToken cancellationToken = default)
    {
        try
        {
            if (doc == null)
                throw new ArgumentNullException(nameof(doc));

            _dbSet.Remove(doc);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (ArgumentNullException e)
        {
            RepoLogs.DeleteAsyncError(logger, e);
        }
    }

    public virtual async Task DeleteByIdAsync(string guid, CancellationToken cancellationToken = default)
    {
        try
        {
            var doc = await GetByIdAsync(guid, cancellationToken);
            if (doc != null)
            {
                _dbSet.Remove(doc);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        catch (Exception e)
        {
            RepoLogs.DeleteByIdAsyncError(logger, e);
        }
    }

    public virtual async Task DeleteManyAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var docs = await _dbSet.Where(predicate).ToListAsync(cancellationToken);
            if (docs.Count != 0)
            {
                _dbSet.RemoveRange(docs);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        catch (Exception e)
        {
            RepoLogs.DeleteManyAsyncError(logger, e);
        }
    }

    #endregion
}