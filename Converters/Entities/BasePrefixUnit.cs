using System.Text;

namespace Converters;

public abstract class BasePrefixUnit : BaseUnit
{
    protected BasePrefixUnit(double value, UnitPrefix prefix) : base(value)
    {
        this.Prefix = prefix;
    }

    protected BasePrefixUnit(UnitPrefix prefix) : base(0)
    {
        this.Prefix = prefix;
    }

    protected BasePrefixUnit(double value) : base(value)
    {
        Prefix = UnitPrefix.EMPTY;
    }

    private UnitPrefix Prefix { get; set; }

    protected double GetValueWithoutPrefix()
    {
        return Value * GetPrefixPower();
    }
    
    public void SetValueWithPrefix(double valueWithoutPrefix)
    {
        this.Value = valueWithoutPrefix / GetPrefixPower();
    }

    private double GetPrefixPower()
    {
        return Math.Pow(10, (int)Prefix);
    }

    public override string PrintString()
    {
        var sb = new StringBuilder(Value.ToString(PrintSpecifier));
        switch (Prefix)
        {
            case UnitPrefix.EMPTY:
                break;
            case UnitPrefix.DECA:
                sb.Append(" deca");
                break;
            case UnitPrefix.HECTO:
                sb.Append(" hecto");
                break;
            case UnitPrefix.KILO:
                sb.Append(" kilo");
                break;
            case UnitPrefix.MEGA:
                sb.Append(" mega");
                break;
            case UnitPrefix.GIGA:
                sb.Append(" giga");
                break;
            case UnitPrefix.TERA:
                sb.Append(" tera");
                break;
            case UnitPrefix.PETA:
                sb.Append(" peta");
                break;
            case UnitPrefix.EXA:
                sb.Append(" exa");
                break;
            case UnitPrefix.ZETTA:
                sb.Append(" zetta");
                break;
            case UnitPrefix.YOTTA:
                sb.Append(" yotta");
                break;
            default:
                break;
        }
        return sb.ToString();
    }
}