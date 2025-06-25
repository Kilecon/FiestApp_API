using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class ExpenseShareDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string ExpenseGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string UserGuid { get; set; }
    public int AmountSharedInCents { get; set; }
}
