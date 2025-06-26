using FiestApp_Infrastructure.Documents;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FiestApp_Infrastructure.Repositories.Base;

public abstract class RepositoryBase<T> : IRepository<T> where T : DocumentBase
{
    protected readonly DbContext Context;
    protected readonly DbSet<T> DbSet;

    protected RepositoryBase(DbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        DbSet = context.Set<T>();
    }

    #region Read Operations

    public virtual async Task<PagedResult<T>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = DbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };
    }

    public virtual async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync(new object[] { id }, cancellationToken: cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    [Obsolete("Better using GetPagedAsync when it's possible")]
    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.CountAsync(predicate, cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(predicate, cancellationToken);
    }

    public virtual async Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default)
    {
        return await DbSet.Select(selector).ToListAsync(cancellationToken);
    }
    #endregion

    #region Write Operations

    public virtual async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.CreatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        entity.UpdatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        await DbSet.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> InsertManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        foreach (var entity in entities)
        {
            entity.CreatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            entity.UpdatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        var entityList = entities.ToList();

        await DbSet.AddRangeAsync(entityList, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entityList;
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.CreatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        DbSet.Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var entities = await DbSet.Where(predicate).ToListAsync(cancellationToken);
        if (entities.Any())
        {
            foreach (var entity in entities)
            {
                entity.CreatedAtUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            }
            DbSet.UpdateRange(entities);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        DbSet.Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteByIdAsync(string guid, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(guid, cancellationToken);
        if (entity != null)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }

    public virtual async Task DeleteManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var entities = await DbSet.Where(predicate).ToListAsync(cancellationToken);
        if (entities.Any())
        {
            DbSet.RemoveRange(entities);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
    #endregion
}