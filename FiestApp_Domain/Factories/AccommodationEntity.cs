using FiestApp_Domain.Dtos.AccommodationDtos;
using FiestApp_Domain.Factories.Base;

namespace FiestApp_Domain.Factories;

public class AccommodationEntity : IFactoryLightBase<Entities.AccommodationEntity, AccommodationDto, AccommodationDto>
{
    public Entities.AccommodationEntity FromDto(AccommodationDto dto)
    {
        return new Entities.AccommodationEntity()
        {
            Guid = new Endto.Guid,
        }
    }

    public Entities.AccommodationEntity FromLightDto(AccommodationDto dto)
    {
        throw new NotImplementedException();
    }

    public AccommodationDto? ToDto(Entities.AccommodationEntity? entity)
    {
        throw new NotImplementedException();
    }

    public AccommodationDto? ToLightDto(Entities.AccommodationEntity? entity)
    {
        throw new NotImplementedException();
    }
}
