using FiestApp_Domain.Dtos.Base;
using FiestApp_Domain.Entities.Base;

namespace FiestApp_Domain.Factories.Base;

public interface IFactoryBase<TEntityBase, TDtoBase>
    where TEntityBase : IEntityBase
    where TDtoBase : IBaseDto
{
    public TDtoBase ToDto(TEntityBase? entity);

    public TEntityBase FromDto(TDtoBase dto);
}