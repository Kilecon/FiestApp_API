using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public sealed class PollOptionEntity : EntityBase
{
    public required Str255Formatted Option { get; set; }
    public required EntityId PollGuid { get; set; }
}
