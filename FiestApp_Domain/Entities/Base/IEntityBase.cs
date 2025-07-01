using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities.Base;

public interface IEntityBase
{
    EntityId Guid { get; set; }
    long CreatedAtUnixTimestamp { get; set; }
    long UpdatedAtUnixTimestamp { get; set; }
}