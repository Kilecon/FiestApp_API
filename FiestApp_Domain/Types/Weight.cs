namespace FiestApp_Domain.Types;
public class Weight
{
    private readonly int _value;
    public Weight(int value)
    {
        if (value <= 0 || value > 700)
            throw new ArgumentOutOfRangeException(nameof(value), "Weight must be between 1 and 500 kg.");

        _value = value;
    }

    public override string ToString() => $"{_value} kg";

    public static implicit operator int(Weight weight) => weight._value;
    public static explicit operator Weight(int value) => new Weight(value);
}
