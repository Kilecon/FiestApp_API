using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities.Base;

public abstract class EntityBase : IEntityBase
{
    public required EntityId Guid { get; set; }
    public long CreatedAtUnixTimestamp { get; set; }
    public long UpdatedAtUnixTimestamp { get; set; }
}
