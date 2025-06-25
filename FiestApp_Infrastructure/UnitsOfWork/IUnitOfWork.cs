namespace FiestApp_Infrastructure.UnitsOfWork;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Sauvegarde tous les changements en base de données
    /// </summary>
    /// <returns>Nombre d'entités affectées</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sauvegarde synchrone des changements
    /// </summary>
    /// <returns>Nombre d'entités affectées</returns>
    int SaveChanges();

    /// <summary>
    /// Démarre une transaction de base de données
    /// </summary>
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Valide la transaction en cours
    /// </summary>
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Annule la transaction en cours
    /// </summary>
    Task RollbackTransactionAsync();

    /// <summary>
    /// Obtient un repository personnalisé
    /// </summary>
    /// <typeparam name="TRepository">Type du repository</typeparam>
    /// <returns>Instance du repository</returns>
    TRepository GetCustomRepository<TRepository>() where TRepository : class;
}
