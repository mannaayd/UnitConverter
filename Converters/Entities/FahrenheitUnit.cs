namespace Converters;

public class FahrenheitUnit : BaseUnit, IConvertibleTo<CelsiusUnit>
{
    public FahrenheitUnit(double value) : base(value)
    { }
    
    public FahrenheitUnit() : base(0)
    { }
    
    public override string PrintString()
    {
        return Value.ToString(PrintSpecifier) + " fahrenheit";
    }

    public void Convert(ref CelsiusUnit t)
    {
        t.Value = (this.Value - 32) * 0.55555556;
    }
}