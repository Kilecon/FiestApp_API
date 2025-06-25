namespace FiestApp_Domain.Entities;

public abstract class EntityBase
{
    public required string Guid { get; set; } = System.Guid.NewGuid().ToString();
    public long CreatedAt { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    public long UpdatedAt { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}
