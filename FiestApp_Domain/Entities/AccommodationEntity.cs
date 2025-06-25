using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public class AccommodationEntity : EntityBase
{
    public required string EventGuid { get; set; } = System.Guid.NewGuid().ToString();
    public required string HostGuid { get; set; } = System.Guid.NewGuid().ToString();
    public required string GuestGuid { get; set; } = System.Guid.NewGuid().ToString();
    public required Enums.Status Status { get; set; }
}
