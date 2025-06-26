using FiestApp_Domain.Types;

namespace FiestApp_Domain.Entities;
public class UserEntity : EntityBase
{
    public required Str50Formatted Username { get; set; }
    public long LastLoginAtUnixTimestamp { get; set; }
}
