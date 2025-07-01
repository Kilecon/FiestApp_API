using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public sealed class AccommodationEntity : EntityBase
{
    public required EntityId EventGuid { get; set; }
    public required EntityId HostGuid { get; set; }
    public required EntityId GuestGuid { get; set; }
    public required Enums.Status Status { get; set; }
}
