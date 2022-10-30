using System.Text;
using System.Text.RegularExpressions;

namespace Converters;


/*
 *  Example input  (from X units, to target unit)-> output:
 *  ("1 meter", "feet") -> "3.28 feet"
 *  ("3 kiloinch", "meter") -> "76.19 meter"
 */
public static class InputHandler
{
    public static string ConvertValue(string valueWithUnit, string targetUnit)
    {
        var sb = new StringBuilder("");
         if (CheckInputTemperature(ref valueWithUnit, ref targetUnit))
         {
            // sb.Append();
            ConvertTemperature(ref valueWithUnit, ref targetUnit);
         }
         else if (CheckInputLength(ref valueWithUnit, ref targetUnit))
         {
          //   sb.Append();
         }
         else if (CheckInputData(ref valueWithUnit, ref targetUnit))
         {
            // sb.Append();
         }
        else throw new InvalidInputException();

        return sb.ToString();
    }

    private static bool CheckInputLength(ref string valueWithUnit, ref string targetUnit)
    {
        return
            Regex.IsMatch(valueWithUnit, @"^\s*[0-9]*.{0,1}[0-9]+\s+((kilo|deca|hecto|mega|giga|tera|peta|exa|zetta|yotta){0,1}meter|feet|inch)") &&
            Regex.IsMatch(targetUnit, @"^\s*((kilo|deca|hecto|mega|giga|tera|peta|exa|zetta|yotta){0,1}meter|feet|inch)");
    }
    
    private static bool CheckInputData(ref string valueWithUnit, ref string targetUnit)
    {
        return
            Regex.IsMatch(valueWithUnit, @"^\s*[0-9]*.{0,1}[0-9]+\s+(kilo|deca|hecto|mega|giga|tera|peta|exa|zetta|yotta){0,1}(byte|bit)") &&
            Regex.IsMatch(targetUnit, @"^\s*(kilo|deca|hecto|mega|giga|tera|peta|exa|zetta|yotta){0,1}(byte|bit)");
    }
    
    private static bool CheckInputTemperature(ref string valueWithUnit, ref string targetUnit)
    {
        return 
            Regex.IsMatch(valueWithUnit, @"^\s*[0-9]*.{0,1}[0-9]+\s+(celsius|fahrenheit)") &&
            Regex.IsMatch(targetUnit, @"^\s*(celsius|fahrenheit)");
    }

    // private static bool ConvertLength(ref string valueWithUnit, ref string targetUnit)
    // {
    //     if()
    // }
    
    // private static bool ConvertData(ref string valueWithUnit, ref string targetUnit)
    // {
    //     
    // }
    //
    private static bool ConvertTemperature(ref string valueWithUnit, ref string targetUnit)
    {
        if (valueWithUnit.Contains("celsius"))
        {
    
        }
        else if (valueWithUnit.Contains("fahrenheit"))
        {
            string [] arr = valueWithUnit.Split(" ");
            decimal d = Decimal.Parse(arr[0]);
            FahrenheitUnit fahrenheit = new FahrenheitUnit(d);
            //if(targetUnit.Contains("fahrenheit")) 
        }

        return true;
    }

    private static SIUnitPrefix GetPrefix(ref string unitWithPrefix)
    {
        SIUnitPrefix prefix = SIUnitPrefix.EMPTY;
        if (unitWithPrefix.Contains("deca")) prefix = SIUnitPrefix.DECA;
        else if (unitWithPrefix.Contains("hecto")) prefix = SIUnitPrefix.HECTO;
        else if (unitWithPrefix.Contains("kilo")) prefix = SIUnitPrefix.KILO;
        else if (unitWithPrefix.Contains("mega")) prefix = SIUnitPrefix.MEGA;
        else if (unitWithPrefix.Contains("giga")) prefix = SIUnitPrefix.GIGA;
        else if (unitWithPrefix.Contains("tera")) prefix = SIUnitPrefix.TERA;
        else if (unitWithPrefix.Contains("peta")) prefix = SIUnitPrefix.PETA;
        else if (unitWithPrefix.Contains("exa")) prefix = SIUnitPrefix.EXA;
        else if (unitWithPrefix.Contains("zetta")) prefix = SIUnitPrefix.ZETTA;
        else if (unitWithPrefix.Contains("yotta")) prefix = SIUnitPrefix.YOTTA;
        return prefix;
    }
}