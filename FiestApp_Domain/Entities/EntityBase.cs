using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public abstract class EntityBase
{
    public required EntityId Guid { get; set; }
    public long CreatedAtUnixTimestampUnixTimestamp { get; set; }
    public long UpdatedAtUnixTimestamp { get; set; }
}
