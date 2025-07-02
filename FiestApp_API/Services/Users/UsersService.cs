using FiestApp_API.Logging;
using FiestApp_API.Services.Base;
using FiestApp_Domain.Entities;
using FiestApp_Domain.Types;
using FiestApp_Infrastructure.Documents;
using FiestApp_Infrastructure.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace FiestApp_API.Services.Users;

public class UsersService(IRepository<UserDocument> repository, ILogger<UsersService> logger)
    : IService<UserDocument, UserEntity>
{
    public virtual async Task<UserEntity?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var res = await repository.GetByIdAsync(id, cancellationToken);
        return ToEntity(res);
    }

    public virtual async Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
#pragma warning disable CS0618
        var result = await repository.GetAllAsync(cancellationToken);
        var entities = new List<UserEntity>();
        try
        {
            foreach (var res in result)
            {
#pragma warning disable CS8604
                entities.Add(ToEntity(res));
#pragma warning restore CS8604
            }
        }
        catch (Exception ex)
        {
            ServiceLogs.GetAllAsyncError(logger, ex);
        }

        return entities;
#pragma warning restore CS0618
    }

    public virtual async Task<UserEntity?> InsertAsync(UserDocument entity,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.InsertAsync(entity, cancellationToken);
        return ToEntity(result);
    }

    public virtual async Task<IEnumerable<UserEntity?>> InsertManyAsync(IEnumerable<UserEntity> entities,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var docs = new List<UserDocument>();
            foreach (var entity in entities)
            {
                var doc = ToDocument(entity);
                if (doc is not null)
                    docs.Add(doc);
            }

            var res = await repository.InsertManyAsync(docs, cancellationToken);
            var result = new List<UserEntity>();
            foreach (var doc in docs)
            {
                var ent = ToEntity(doc);
                if (ent is not null)
                    result.Add(ent);
            }

            return result;
        }
        catch (Exception e)
        {
            ServiceLogs.InsertManyAsyncError(logger, e);
            return new List<UserEntity>();
        }
    }

    public virtual async Task<UserEntity?> UpdateAsync(UserDocument entity,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.UpdateAsync(entity, cancellationToken);
        return ToEntity(result);
    }

    public virtual async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        await repository.DeleteByIdAsync(id, cancellationToken);
    }

    private UserEntity? ToEntity(UserDocument? doc)
    {
        try
        {
            return new UserEntity(
                    Enums.GetEnumValueFromDescription<Enums.Gender>(doc?.Gender),
                    new Age(doc?.Age),
                    new Height(doc?.Height),
                    new Weight(doc?.Weight),
                    Enums.GetEnumValueFromDescription<Enums.AlcoholConsumption>(doc?.AlcoholConsumption)
                )
                { Guid = new EntityId(doc?.Guid ?? ""), Username = new Str50Formatted(doc?.Username ?? "") };
        }
        catch (Exception ex)
        {
            ServiceLogs.ToEntityError(logger, ex);
        }

        return null;
    }

    private UserDocument? ToDocument(UserEntity entity)
    {
        try
        {
            return new UserDocument
            {
                Gender = entity.Gender.ToString(),
                Age = entity.Age,
                Height = entity.Height,
                Weight = entity.Weight,
                AlcoholConsumption = entity.AlcoholConsumption.ToString(),
                Guid = entity.Guid,
                Username = entity.Username
            };
        }
        catch (Exception ex)
        {
            ServiceLogs.ToDocumentError(logger, ex);
        }

        return null;
    }
}