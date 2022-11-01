namespace Converters;

public class CelsiusUnit : BaseUnit, IConvertibleTo<FahrenheitUnit>
{
    public CelsiusUnit(double value) : base(value)
    { }

    public CelsiusUnit() : base(0)
    { }

    public override string PrintString()
    {
        return Value.ToString(PrintSpecifier) + " celsius";
    }

    public void Convert(ref FahrenheitUnit t)
    {
        t.Value = (this.Value * 1.8) + 32;
    }
}