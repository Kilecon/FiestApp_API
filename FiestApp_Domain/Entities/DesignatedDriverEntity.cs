
using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public sealed class DesignatedDriverEntity : EntityBase
{
    public required EntityId EventGuid { get; set; }
    public required EntityId DriverGuid { get; set; }
    public required Enums.Status Status { get; set; }
}
