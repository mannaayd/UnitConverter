namespace Converters;

public abstract class BaseUnit
{
    public decimal Value { get; set; }

    protected BaseUnit(decimal Value)
    {
        this.Value = Value;
    }
}