using FiestApp_Infrastructure.Documents.Base;
using System.Linq.Expressions;

namespace FiestApp_Infrastructure.Repositories.Base;

public interface IRepository<T> : IReadOnlyAccessor<T> where T : DocumentBase
{
    Task InsertAsync(T doc, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> InsertManyAsync(IEnumerable<T> docs, CancellationToken cancellationToken = default);
    Task UpdateAsync(T doc, CancellationToken cancellationToken = default);
    Task PartialUpdateAsync<TPartial>(TPartial partialDoc,
        CancellationToken cancellationToken = default) where TPartial : T;
    Task UpdateManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task PartialUpdateManyAsync<TPartial>(IEnumerable<TPartial> partialDocs,
    CancellationToken cancellationToken = default) where TPartial : T;
    Task DeleteAsync(T doc, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(string guid, CancellationToken cancellationToken = default);
    Task DeleteManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}

public interface IReadOnlyAccessor<T> where T : class
{
    Task<PagedResult<T>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes);

    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    [Obsolete("Better using GetPagedAsync when it's possible")]
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);
}