namespace Converters;

public class MeterUnit : BasePrefixUnit
{
    public MeterUnit(decimal value, SIUnitPrefix prefix) : base(value, prefix)
    { }

    public MeterUnit(SIUnitPrefix prefix) : base(prefix)
    { }

    public override string PrintString()
    {
        return Value.ToString(specifier) +  base.PrintString() + "meter";
    }
}