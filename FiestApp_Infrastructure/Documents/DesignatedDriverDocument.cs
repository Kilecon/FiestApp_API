using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class DesignatedDriverDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string EventGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string DriverGuid { get; set; }
    [StringLength(2, MinimumLength = 2)]
    public required string Status { get; set; }
}
