using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class ShoppingItemDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string ShoppingListGuid { get; set; }
    [StringLength(255, MinimumLength = 0)]
    public required string Name { get; set; }
    public short Quantity { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string AssignedToGuid { get; set; }
    public bool IsBought { get; set; }

    public required UserDocument AssignedUser { get; set; }
    public required ShoppingListDocument ShoppingList { get; set; }
}
