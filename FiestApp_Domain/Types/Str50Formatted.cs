namespace FiestApp_Domain.Types;

public sealed class Str50Formatted
{
    private readonly string _value;
    public Str50Formatted(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Title cannot be empty or whitespace.");

        var trimmed = value.Trim();

        if (trimmed.Length > 50)
            throw new ArgumentException("Title cannot be longer than 50 characters.");

        if (!char.IsUpper(trimmed[0]))
            throw new ArgumentException("Title must start with an uppercase letter.");

        _value = trimmed;
    }

    public override string ToString() => _value;

    public static implicit operator string(Str50Formatted title) => title._value;
    public static explicit operator Str50Formatted(string value) => new Str50Formatted(value);
}