using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public sealed class InvitationEntity : EntityBase
{
    public required EntityId UserGuid { get; set; }
    public required EntityId EventGuid { get; set; }
    public required Enums.Status Status { get; set; }
}
