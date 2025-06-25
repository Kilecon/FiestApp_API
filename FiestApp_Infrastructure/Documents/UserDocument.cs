using System.ComponentModel.DataAnnotations;

namespace FiestApp_Infrastructure.Documents;
public class UserDocument : DocumentBase
{
    public required string Username { get; set; }
    [ConcurrencyCheck]
    public long LastLoginAtUnixTimestamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}
