using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public sealed class ExpenseShareEntity : EntityBase
{
    public required EntityId ExpenseGuid { get; set; }
    public required EntityId UserGuid { get; set; }
    public required Amount AmountSharedInCents { get; set; }
}
