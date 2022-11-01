namespace Converters;

public class BitUnit : BasePrefixUnit, IConvertibleTo<ByteUnit>, IConvertibleTo<BitUnit>
{
    public BitUnit(double value, UnitPrefix prefix) : base(value, prefix)
    { }
    
    public BitUnit(UnitPrefix prefix) : base(prefix)
    { }

    public override string PrintString()
    {
        return base.PrintString() + "bit";
    }
    
    public void Convert(ref ByteUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix() / 8);
    }

    public void Convert(ref BitUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix());
    }
}