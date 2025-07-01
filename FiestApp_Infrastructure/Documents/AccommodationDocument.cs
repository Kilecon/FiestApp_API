using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class AccommodationDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string EventGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string HostGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public string? GuestGuid { get; set; }
    public int AvailableSlots { get; set; }
    [StringLength(2, MinimumLength = 2)]
    public required string Status { get; set; }
    public required EventDocument Event { get; set; }
    public required UserDocument Host { get; set; }
    public UserDocument? Guest { get; set; }
}