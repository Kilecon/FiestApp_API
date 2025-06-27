namespace FiestApp_Domain.Types;
public class Height
{
    private readonly int? _value;

    public Height(int? value)
    {
        if (value <= 0 || value > 300)
            throw new ArgumentOutOfRangeException(nameof(value), "Height must be between 30 and 300 cm.");

        _value = value;
    }

    public override string ToString() => $"{_value} cm";

    public static implicit operator int?(Height height) => height._value;
    public static explicit operator Height(int value) => new Height(value);
}
