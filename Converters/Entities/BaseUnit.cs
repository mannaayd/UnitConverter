namespace Converters;

public abstract class BaseUnit
{
    public double Value { get; set; }
    
    protected const string PrintSpecifier = "0.000";
    protected BaseUnit(double value)
    {
        this.Value = value;
    }

    public abstract string PrintString();
}