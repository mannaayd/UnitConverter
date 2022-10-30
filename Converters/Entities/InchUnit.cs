namespace Converters;

public class InchUnit : BaseUnit
{
    public InchUnit(decimal value) : base(value)
    { }

    public override string PrintString()
    {
        return Value.ToString(specifier) + " inch";
    }
}