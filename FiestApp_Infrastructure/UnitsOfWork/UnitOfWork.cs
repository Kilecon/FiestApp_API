
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace FiestApp_Infrastructure.UnitsOfWork;


public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<Type, object> _repositories = new();
    private IDbContextTransaction _transaction;
    private bool _disposed = false;

    public UnitOfWork(DbContext context, IServiceProvider serviceProvider)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            // Log l'erreur et relancer
            throw new InvalidOperationException("Erreur lors de la sauvegarde des données", ex);
        }
    }

    public int SaveChanges()
    {
        try
        {
            return _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            // Log l'erreur et relancer
            throw new InvalidOperationException("Erreur lors de la sauvegarde des données", ex);
        }
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
            throw new InvalidOperationException("Une transaction est déjà en cours");

        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction == null)
            throw new InvalidOperationException("Aucune transaction n'est en cours");

        try
        {
            await _transaction.CommitAsync(cancellationToken);
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction == null)
            throw new InvalidOperationException("Aucune transaction n'est en cours");

        try
        {
            await _transaction.RollbackAsync();
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public TRepository GetCustomRepository<TRepository>() where TRepository : class
    {
        var repositoryType = typeof(TRepository);

        if (_repositories.ContainsKey(repositoryType))
            return (TRepository)_repositories[repositoryType];

        var repository = _serviceProvider.GetService<TRepository>();
        if (repository == null)
            throw new InvalidOperationException($"Repository {repositoryType.Name} n'est pas enregistré dans le conteneur DI");

        _repositories[repositoryType] = repository;
        return repository;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _transaction?.Dispose();
            _context?.Dispose();
            _repositories.Clear();
            _disposed = true;
        }
    }
}