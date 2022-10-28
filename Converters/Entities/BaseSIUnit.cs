namespace Converters;

public abstract class BaseSIUnit 
{
    public SIUnitPrefix Prefix { get; set; }
    public double Value { get; set; }

    public double GetValueWithoutPrefix()
    {
        return Value * Math.Pow(10, (int)Prefix);
    }
}