using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class AccommodationDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string EventGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string HostGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string GuestGuid { get; set; }
    [StringLength(2, MinimumLength = 2)]
    public required string Status { get; set; }
}
