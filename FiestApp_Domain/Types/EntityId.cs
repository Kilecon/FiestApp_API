namespace FiestApp_Domain.Types;

public sealed class EntityId
{
    private readonly string _value;

    public EntityId(string? value)
    {
        if (!Guid.TryParse(value, out var guid))
            throw new ArgumentException("Invalid GUID format.");

        _value = guid.ToString();
    }

    public static EntityId New() => new EntityId(Guid.NewGuid().ToString());

    public override string ToString() => _value;

    public override bool Equals(object? obj)
        => obj is EntityId other && _value.Equals(other._value, StringComparison.OrdinalIgnoreCase);

    public override int GetHashCode() => _value.GetHashCode(StringComparison.OrdinalIgnoreCase);

    public static implicit operator string(EntityId id) => id._value;
    public static explicit operator EntityId(string value) => new EntityId(value);
}
