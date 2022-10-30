namespace Converters;

public class FeetUnit : BaseUnit
{
    public FeetUnit(decimal value) : base(value)
    { }

    public override string PrintString()
    {
        return Value.ToString(specifier) + " feet";
    }
}