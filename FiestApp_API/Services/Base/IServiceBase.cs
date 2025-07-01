using FiestApp_Domain.Entities.Base;
using FiestApp_Infrastructure.Documents.Base;

namespace FiestApp_API.Services.Base;

public interface IService<T, R>
    where T : IDocumentBase
    where R : IEntityBase
{
    Task<R?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<R>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<R?> InsertAsync(T entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<R?>> InsertManyAsync(IEnumerable<R> entities, CancellationToken cancellationToken = default);
    Task<R?> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}