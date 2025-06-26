namespace FiestApp_Domain.Types;

public sealed class Str255Formatted
{
    private readonly string _value;

    public Str255Formatted(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location cannot be empty or whitespace.");

        var trimmed = location.Trim();

        if (trimmed.Length > 255)
            throw new ArgumentException("Location cannot be longer than 255 characters.");

        _value = trimmed;
    }

    public override string ToString() => _value;

    public static implicit operator string(Str255Formatted location) => location._value;
    public static explicit operator Str255Formatted(string value) => new Str255Formatted(value);
}
