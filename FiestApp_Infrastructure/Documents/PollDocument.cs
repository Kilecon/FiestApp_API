using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class PollDocument : DocumentBase
{
    [StringLength(255, MinimumLength = 0)]
    public required string Question { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string EventGuid { get; set; }
    [StringLength(2, MinimumLength = 2)]
    public required string Status { get; set; }
}
