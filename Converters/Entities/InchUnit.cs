namespace Converters;

internal class InchUnit : BasePrefixUnit, IConvertibleTo<MeterUnit>, IConvertibleTo<InchUnit>, IConvertibleTo<FeetUnit>
{
    public InchUnit(double value, UnitPrefix prefix) : base(value, prefix)
    { }
    
    public InchUnit(UnitPrefix prefix) : base(prefix)
    { }

    public override string PrintString()
    {
        return base.PrintString() + " inch";
    }

    public void Convert(ref MeterUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix() * 0.0254);
    }

    public void Convert(ref InchUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix());
    }

    public void Convert(ref FeetUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix() / 12);
    }
}