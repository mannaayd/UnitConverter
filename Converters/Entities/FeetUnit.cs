namespace Converters;

internal class FeetUnit : BasePrefixUnit, IConvertibleTo<MeterUnit>, IConvertibleTo<InchUnit>, IConvertibleTo<FeetUnit>
{
    public FeetUnit(double value, UnitPrefix prefix) : base(value, prefix)
    { }

    public FeetUnit(UnitPrefix prefix) : base(prefix)
    { }

    public override string PrintString()
    {
        return base.PrintString() + " feet";
    }

    public void Convert(ref MeterUnit t)
    {
        t.SetValueWithPrefix(this.Value * 0.3048);
    }

    public void Convert(ref InchUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix() * 12);
    }

    public void Convert(ref FeetUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix());
    }
}