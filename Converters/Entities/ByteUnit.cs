namespace Converters;

public class ByteUnit : BasePrefixUnit, IConvertibleTo<BitUnit>, IConvertibleTo<ByteUnit>
{
    public ByteUnit(double value, UnitPrefix prefix) : base(value, prefix)
    { }
    
    public ByteUnit(UnitPrefix prefix) : base(prefix)
    { }

    public override string PrintString()
    {
        return base.PrintString() + "byte";
    }

    public void Convert(ref BitUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix() * 8);
    }

    public void Convert(ref ByteUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix());
    }
}