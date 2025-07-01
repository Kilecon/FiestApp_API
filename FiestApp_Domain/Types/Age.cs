namespace FiestApp_Domain.Types;

public class Age
{
    private readonly int? _value;
    public Age(int? value)
    {
        if (value < 0 || value > 150)
            throw new ArgumentOutOfRangeException(nameof(value), "Age must be between 0 and 150.");

        _value = value;
    }

    public override string ToString() => $"{_value}";

    public static implicit operator int?(Age age) => age?._value;
    public static explicit operator Age(int? value) => new Age(value);
}
