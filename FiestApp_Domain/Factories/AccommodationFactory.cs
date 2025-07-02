using FiestApp_Domain.Dtos.AccommodationDtos;
using FiestApp_Domain.Factories.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Factories;

public class AccommodationFactory : IFactoryLightBase<Entities.AccommodationEntity, AccommodationDto, AccommodationDto>
{
    public Entities.AccommodationEntity FromDto(AccommodationDto dto)
    {
        return new Entities.AccommodationEntity()
        {
            Guid = new EntityId(dto.Guid),
            EventGuid = new EntityId(dto.Event.Guid),
            HostGuid = new EntityId(dto.Host.Guid),
            AvailableSlots = dto.AvailableSlots,
            GuestGuid = new EntityId(dto.Guest?.Guid),
            Status = Enums.GetEnumValueFromDescription<Enums.Status>(dto.Status),

        };
    }

    public Entities.AccommodationEntity FromLightDto(AccommodationDto dto)
    {
        return new Entities.AccommodationEntity()
        {
            Guid = new EntityId(Guid.NewGuid().ToString()),
            EventGuid = new EntityId(dto.Event.Guid),
            HostGuid = new EntityId(dto.Host.Guid),
            AvailableSlots = dto.AvailableSlots,
            GuestGuid = new EntityId(dto.Guest?.Guid),
            Status = Enums.GetEnumValueFromDescription<Enums.Status>(dto.Status),

        };
    }

    public AccommodationDto? ToDto(Entities.AccommodationEntity? entity)
    {
        if (entity == null)
            return null;
        return new AccommodationDto()
        {
            Guid = entity.Guid,
            Status = Enums.GetDescription(entity.Status),
            Event = new Dtos.EventDtos.EventDto() { Guid = entity.EventGuid },



        };
    }

    public AccommodationDto? ToLightDto(Entities.AccommodationEntity? entity)
    {
        throw new NotImplementedException();
    }
}
