namespace FiestApp_Domain.Types;

public sealed class Amount
{
    private readonly int _centAmount;

    public Amount(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Amount cannot be negative.");

        decimal centValue = Math.Round(value * 100, MidpointRounding.AwayFromZero);

        if (centValue > int.MaxValue)
            throw new OverflowException("Amount is too large to be represented as long in cents.");

        _centAmount = (int)centValue;
    }

    public decimal ToDecimal() => _centAmount / 100m;

    public override string ToString() => $"{ToDecimal():0.00}";

    public static implicit operator long(Amount amount) => amount._centAmount;
    public static explicit operator Amount(decimal value) => new Amount(value);
}
