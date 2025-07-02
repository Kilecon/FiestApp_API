using FiestApp_Domain.Dtos.EventDtos;
using FiestApp_Domain.Entities;
using FiestApp_Domain.Factories.Base;

namespace FiestApp_Domain.Factories;

public class EventFactory : IFactoryLightBase<EventEntity, EventDto, EventDto>
{
    public EventEntity FromDto(EventDto dto)
    {
        return new EventEntity()
        {
            Guid = new Types.EntityId(dto.Guid),
            Creator = new Types.EntityId(dto.Organazer.Guid),
            Description = new Types.Text(dto.Description),
            Title = new Types.Str50Formatted(dto.Title),
            Location = new Types.Str255Formatted(dto.Location),
            Latitude = dto.Latitute,
            Longitude = dto.Longitude,
            Date = dto.Date
        };
    }

    public EventEntity FromLightDto(EventDto dto)
    {
        return new EventEntity()
        {
            Guid = new Types.EntityId(Guid.NewGuid().ToString()),
            Creator = new Types.EntityId(dto.Organazer.Guid),
            Description = new Types.Text(dto.Description),
            Title = new Types.Str50Formatted(dto.Title),
            Location = new Types.Str255Formatted(dto.Location),
            Latitude = dto.Latitute,
            Longitude = dto.Longitude,
            Date = dto.Date
        };
    }

    public EventDto? ToDto(EventEntity? entity)
    {
        if (entity == null)
            return null;
        return new EventDto()
        {
            Guid = entity.Guid,
            Date = entity.Date,
            Description = entity.Description,
            Title = entity.Title,
            Location = entity.Location,
            Longitude = entity.Longitude,
            Latitute = entity.Latitude,
            Organazer = new Dtos.UserDtos.LightUserDto() { Guid = entity.Creator, Username = "" },
        };
    }

    [Obsolete("Do not use !")]
    public EventDto? ToLightDto(EventEntity? entity)
    {
        throw new NotImplementedException();
    }
}
