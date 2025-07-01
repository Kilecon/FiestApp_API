using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents.Base;

public abstract class DocumentBase : IDocumentBase
{
    [Key]
    [StringLength(36, MinimumLength = 36)]
    public required string Guid { get; set; }
    [ConcurrencyCheck]
    public long CreatedAtUnixTimestamp { get; set; }
    [ConcurrencyCheck]
    public long UpdatedAtUnixTimestamp { get; set; }
}
