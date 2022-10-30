namespace Converters;

public abstract class BasePrefixUnit : BaseUnit
{
    protected BasePrefixUnit(decimal Value) : base(Value)
    { }

    private SIUnitPrefix Prefix { get; set; }

    public decimal GetValueWithoutPrefix()
    {
        // possible loss of value accuracy
        return Value * (decimal)Math.Pow(10, (int)Prefix);
    }
}