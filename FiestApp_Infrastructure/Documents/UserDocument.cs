using FiestApp_Infrastructure.Documents.Base;
using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;
public class UserDocument : DocumentBase
{
    public required string Username { get; set; }
    [ConcurrencyCheck]
    public long LastLoginAtUnixTimestamp { get; set; }
    public string? Gender { get; set; }
    public int? Age { get; set; }
    public int? Height { get; set; }
    public int? Weight { get; set; }
    public string? AlcoholConsumption { get; set; }
}
