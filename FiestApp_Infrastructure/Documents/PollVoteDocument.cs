using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class PollVoteDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string PollGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string UserGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string PollOptionGuid { get; set; }

    public required PollOptionDocument Option { get; set; }
    public required PollDocument Poll { get; set; }
    public required UserDocument User { get; set; }
}
