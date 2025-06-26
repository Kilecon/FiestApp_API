using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public sealed class ExpenseEntity : EntityBase
{
    public required EntityId EventGuid { get; set; }
    public required EntityId PayerGuid { get; set; }
    public required Str255Formatted label { get; set; }
    public required Amount AmountInCents { get; set; }
}
