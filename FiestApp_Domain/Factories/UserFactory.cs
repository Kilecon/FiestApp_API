using FiestApp_Domain.Dtos.UserDtos;
using FiestApp_Domain.Entities;
using FiestApp_Domain.Factories.Base;
using FiestApp_Domain.Logging;
using FiestApp_Domain.Types;
using Microsoft.Extensions.Logging;

namespace FiestApp_Domain.Factories;

public class UserFactory(ILogger<UserFactory> logger) : IFactoryLightBase<UserEntity, UserDto, LightUserDto>
{
    public UserDto? ToDto(UserEntity? entity)
    {
        if (entity == null)
        {
            FactoryLogs.ToDtoWarning(logger);
            return null;
        }

        return new UserDto
        {
            Guid = entity.Guid,
            Username = entity.Username.ToString(),
            Gender = entity.Gender.ToString(),
            Age = entity.Age,
            Height = entity.Height,
            Weight = entity.Weight,
            AlcoholConsumption = entity.AlcoholConsumption.ToString()
        };
    }

    public LightUserDto? ToLightDto(UserEntity? entity)
    {
        if (entity == null)
        {
            FactoryLogs.ToLightDtoWarning(logger);
            return null;
        }

        return new LightUserDto
        {
            Guid = entity.Guid,
            Username = entity.Username.ToString()
        };
    }

    public UserEntity FromDto(UserDto dto)
    {
        return new UserEntity(
            Enums.GetEnumValueFromDescription<Enums.Gender>(dto.Gender),
            new Age(dto.Age),
            new Height(dto.Height),
            new Weight(dto.Weight),
            Enums.GetEnumValueFromDescription<Enums.AlcoholConsumption>(dto.AlcoholConsumption)
        )
        {
            Guid = new EntityId(dto.Guid),
            Username = new Str50Formatted(dto.Username)
        };
    }

    public UserEntity FromLightDto(LightUserDto dto)
    {
        return new UserEntity(null, new Age(null), new Height(null), new Weight(null), null)
        {
            Guid = new EntityId(dto.Guid),
            Username = new Str50Formatted(dto.Username)
        };
    }
}