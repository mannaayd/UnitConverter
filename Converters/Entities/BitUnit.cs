namespace Converters;

public class BitUnit : BasePrefixUnit
{
    public BitUnit(decimal value, SIUnitPrefix prefix) : base(value, prefix)
    { }
    
    public BitUnit(SIUnitPrefix prefix) : base(prefix)
    { }

    public override string PrintString()
    {
        return Value.ToString(specifier) + base.PrintString() + "bit";
    }
}