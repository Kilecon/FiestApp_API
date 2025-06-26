namespace FiestApp_Domain.Types;

public sealed class Text
{
    private readonly string _value;

    public Text(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty or whitespace.");

        var trimmed = description.Trim();

        if (!char.IsUpper(trimmed[0]))
            throw new ArgumentException("Description must start with an uppercase letter.");

        _value = trimmed;
    }

    public override string ToString() => _value;

    public static implicit operator string(Text description) => description._value;
    public static explicit operator Text(string value) => new Text(value);
}
