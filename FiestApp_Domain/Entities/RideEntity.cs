using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public sealed class RideEntity : EntityBase
{
    public required EntityId EventGuid { get; set; }
    public required EntityId DriverGuid { get; set; }
    public int AvailableSlots { get; set; }
    public required EntityId PassengerGuid { get; set; }
    public required Enums.Status Status { get; set; }

}
