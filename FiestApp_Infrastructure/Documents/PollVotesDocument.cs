using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class PollVotesDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string PollGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string UserGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string PollOptionGuid { get; set; }
}
