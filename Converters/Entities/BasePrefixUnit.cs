using System.Text;

namespace Converters;

public abstract class BasePrefixUnit : BaseUnit
{
    protected BasePrefixUnit(decimal value, SIUnitPrefix prefix) : base(value)
    {
        this.Prefix = prefix;
    }

    protected BasePrefixUnit(SIUnitPrefix prefix) : base(0m)
    {
        this.Prefix = prefix;
    }

    private SIUnitPrefix Prefix { get; set; }

    public decimal GetValueWithoutPrefix()
    {
        return Decimal.Multiply(Value, GetPrefixPower());
    }
    
    public void SetValueWithPrefix(decimal valueWithoutPrefix)
    {
        this.Value = Decimal.Divide(valueWithoutPrefix, GetPrefixPower());
    }

    private decimal GetPrefixPower()
    {
        decimal res = 1m;
        for (int i = 0; i < (int)Prefix; i++)
        {
            res = Decimal.Multiply(res, 10m);
        }
        return res;
    }

    public override string PrintString()
    {
        StringBuilder sb = new StringBuilder(" ");
        switch (Prefix)
        {
            case SIUnitPrefix.EMPTY:
                break;
            case SIUnitPrefix.DECA:
                sb.Append("deca");
                break;
            case SIUnitPrefix.HECTO:
                sb.Append("hecto");
                break;
            case SIUnitPrefix.KILO:
                sb.Append("kilo");
                break;
            case SIUnitPrefix.MEGA:
                sb.Append("mega");
                break;
            case SIUnitPrefix.GIGA:
                sb.Append("giga");
                break;
            case SIUnitPrefix.TERA:
                sb.Append("tera");
                break;
            case SIUnitPrefix.PETA:
                sb.Append("peta");
                break;
            case SIUnitPrefix.EXA:
                sb.Append("exa");
                break;
            case SIUnitPrefix.ZETTA:
                sb.Append("zetta");
                break;
            case SIUnitPrefix.YOTTA:
                sb.Append("yotta");
                break;
            default:
                break;
        }
        return sb.ToString();
    }
}