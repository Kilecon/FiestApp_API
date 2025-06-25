
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public class DesignatedDriverEntity : EntityBase
{
    public required string EventGuid { get; set; }
    public required string DriverGuid { get; set; }
    public required Enums.Status Status { get; set; }
}
