using FiestApp_API.Dtos.Base;
using FiestApp_Domain.Entities.Base;

namespace FiestApp_Domain.Factories.Base;

public interface IFactoryLightBase<TEntityBase, TDtoBase, TDtoLightBase>
    where TEntityBase : IEntityBase
    where TDtoBase : IBaseDto
    where TDtoLightBase : IBaseDto
{
    public abstract TDtoBase? ToDto(TEntityBase? entity);

    public TDtoLightBase? ToLightDto(TEntityBase? entity);

    public TEntityBase FromDto(TDtoBase dto);

    public TEntityBase FromLightDto(TDtoLightBase dto);
}