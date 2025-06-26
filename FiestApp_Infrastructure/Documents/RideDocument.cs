using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class RideDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string EventGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string DriverGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string PassengerGuid { get; set; }
}
