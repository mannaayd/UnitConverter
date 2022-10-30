namespace Converters;

public class CelsiusUnit : BaseUnit
{
    public CelsiusUnit(decimal value) : base(value)
    { }

    public override string PrintString()
    {
        return Value.ToString(specifier) + " celsius";
    }
}