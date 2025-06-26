using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class PollOptionDocument : DocumentBase
{
    [StringLength(255, MinimumLength = 0)]
    public required string Question { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string PollGuid { get; set; }
}
