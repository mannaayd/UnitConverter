namespace Converters;

internal class MeterUnit : BasePrefixUnit, IConvertibleTo<InchUnit>, IConvertibleTo<FeetUnit>, IConvertibleTo<MeterUnit>
{
    public MeterUnit(double value, UnitPrefix prefix) : base(value, prefix)
    { }

    public MeterUnit(UnitPrefix prefix) : base(prefix)
    { }

    public override string PrintString()
    {
        return base.PrintString() + "meter";
    }

    public void Convert(ref InchUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix() / 0.0254);
    }

    public void Convert(ref FeetUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix() * 3.280839895);
    }

    public void Convert(ref MeterUnit t)
    {
        t.SetValueWithPrefix(this.GetValueWithoutPrefix());
    }
}