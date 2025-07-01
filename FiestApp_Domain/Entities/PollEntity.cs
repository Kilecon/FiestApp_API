using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public sealed class PollEntity : EntityBase
{
    public required Str255Formatted Question { get; set; }
    public required EntityId EventGuid { get; set; }
    public required Enums.Status Status { get; set; }
}
