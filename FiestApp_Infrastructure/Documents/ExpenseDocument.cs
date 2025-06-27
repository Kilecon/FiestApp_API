using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;

public class ExpenseDocument : DocumentBase
{
    [StringLength(36, MinimumLength = 36)]
    public required string EventGuid { get; set; }
    [StringLength(36, MinimumLength = 36)]
    public required string PayerGuid { get; set; }
    [StringLength(255, MinimumLength = 0)]
    public required string Label { get; set; }
    public int AmountInCents { get; set; }

    public required EventDocument Event { get; set; }
    public required UserDocument Payer { get; set; }
}
