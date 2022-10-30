namespace Converters;

public class ByteUnit : BasePrefixUnit
{
    public ByteUnit(decimal value, SIUnitPrefix prefix) : base(value, prefix)
    { }
    
    public ByteUnit(SIUnitPrefix prefix) : base(prefix)
    { }

    public override string PrintString()
    {
        return Value.ToString(specifier) + base.PrintString() + "byte";
    }
}