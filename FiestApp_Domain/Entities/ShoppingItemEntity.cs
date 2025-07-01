using FiestApp_Domain.Entities.Base;
using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;

public class ShoppingItemEntity : EntityBase
{
    public required EntityId ListGuid { get; set; }
    public required Str255Formatted Name { get; set; }
    public int Quantity { get; set; }
    public required string EntityId { get; set; }
    public required EntityId AssignedTo { get; set; }
    public bool IsBought { get; set; }
}
