namespace Converters;

public abstract class BaseUnit
{
    public decimal Value { get; set; }
    
    protected const string specifier = "0.000";
    protected BaseUnit(decimal value)
    {
        this.Value = value;
    }

    public abstract string PrintString();
}