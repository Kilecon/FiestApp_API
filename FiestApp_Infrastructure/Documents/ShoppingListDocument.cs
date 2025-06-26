using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class ShoppingListDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string EventGuid { get; set; }
}
