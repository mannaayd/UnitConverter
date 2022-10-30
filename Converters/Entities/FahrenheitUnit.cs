namespace Converters;

public class FahrenheitUnit : BaseUnit
{
    public FahrenheitUnit(decimal value) : base(value)
    { }

    public override string PrintString()
    {
        return Value.ToString(specifier) + " fahrenheit";
    }
}