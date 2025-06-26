using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public sealed class PollVoteEntity : EntityBase
{
    public required EntityId PollGuid { get; set; }
    public required EntityId UserGuid { get; set; }
    public required EntityId PollOptionGuid { get; set; }
}
