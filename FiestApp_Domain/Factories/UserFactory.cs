using FiestApp_API.Dtos.UserDtos;
using FiestApp_Domain.Entities;
using FiestApp_Domain.Factories.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Factories;

public class UserFactory : IFactoryLightBase<UserEntity, UserDto, LightUserDto>
{
    public UserDto? ToDto(UserEntity? entity)
    {
        if (entity == null)
            return null;

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
            return null;

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

    public UserEntity FromDto(LightUserDto dto)
    {
        return new UserEntity(null, new Age(null), new Height(null), new Weight(null), null)
        {
            Guid = new EntityId(dto.Guid),
            Username = new Str50Formatted(dto.Username)
        };
    }
}