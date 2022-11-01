using System.Text;
using System.Text.RegularExpressions;

namespace Converters;

internal static class UnitParser
{
    public static string ConvertStrings(string valueWithUnit, string targetUnit)
    {
        var sb = new StringBuilder();
        string givenUnit = null;
        double value = 0;
        if (TryParseTemperature(ref valueWithUnit, ref targetUnit, ref givenUnit, ref value))
        {
            sb.Append(ConvertTemperature(ref value, ref givenUnit, ref targetUnit));
        }
        else if (TryParseLength(ref valueWithUnit, ref targetUnit, ref givenUnit, ref value))
        {
            sb.Append(ConvertLength(ref value, ref givenUnit, ref targetUnit));
        }
        else if (TryParseData(ref valueWithUnit, ref targetUnit, ref givenUnit, ref value))
        {
            sb.Append(ConvertData(ref value, ref givenUnit, ref targetUnit));
        }
        else throw new InvalidInputException();

        return sb.ToString();
    }

    private static string? ConvertTemperature(ref double value ,ref string givenUnit, ref string targetUnit)
    {
        BaseUnit? unit = null;
        if (givenUnit.Contains("fahrenheit"))
        {
            unit = new FahrenheitUnit(value);
        }
        else if (givenUnit.Contains("celsius"))
        {
            unit = new CelsiusUnit(value);
        }
        else throw new InvalidInputException();

        BaseUnit? convertedUnit = null;
        if (targetUnit.Contains("fahrenheit"))
        {
            var unitConverterInterface = unit as IConvertibleTo<FahrenheitUnit>;
            var fahrenheitUnit = new FahrenheitUnit();
            unitConverterInterface?.Convert(ref fahrenheitUnit);
            convertedUnit = fahrenheitUnit;
        }
        else if (targetUnit.Contains("celsius"))
        {
            var unitConverterInterface = unit as IConvertibleTo<CelsiusUnit>;
            var celsiusUnit = new CelsiusUnit();
            unitConverterInterface?.Convert(ref celsiusUnit);
            convertedUnit = celsiusUnit;
        }
        else throw new NoConversionException();
        return convertedUnit?.PrintString();
    }

    private static string ConvertLength(ref double value ,ref string givenUnit, ref string targetUnit)
    {
        BaseUnit? unit = null;
        var givenUnitPrefix = GetPrefix(ref givenUnit);
        var targetUnitPrefix = GetPrefix(ref targetUnit);
        if (givenUnit.Contains("meter")) 
        {
            unit = new MeterUnit(value, givenUnitPrefix);
        }
        else if (givenUnit.Contains("feet"))
        {
            unit = new FeetUnit(value, givenUnitPrefix);
        }
        else if (givenUnit.Contains("inch"))
        {
            unit = new InchUnit(value, givenUnitPrefix);
        }
        
        BaseUnit? convertedUnit = null;
        
        if (targetUnit.Contains("meter"))
        {
            var unitConverterInterface = unit as IConvertibleTo<MeterUnit>;
            var meterUnit = new MeterUnit(targetUnitPrefix);
            unitConverterInterface?.Convert(ref meterUnit);
            convertedUnit = meterUnit;
        }
        else if (targetUnit.Contains("feet"))
        {
            var unitConverterInterface = unit as IConvertibleTo<FeetUnit>;
            var feetUnit = new FeetUnit(targetUnitPrefix);
            unitConverterInterface?.Convert(ref feetUnit);
            convertedUnit = feetUnit;
        }
        else if (targetUnit.Contains("inch"))
        {
            var unitConverterInterface = unit as IConvertibleTo<InchUnit>;
            var inchUnit = new InchUnit(targetUnitPrefix);
            unitConverterInterface?.Convert(ref inchUnit);
            convertedUnit = inchUnit;
        }
        else throw new NoConversionException(); 
        return convertedUnit?.PrintString();
    }
    
    private static string ConvertData(ref double value ,ref string givenUnit, ref string targetUnit)
    {
        BaseUnit? unit = null;
        var givenUnitPrefix = GetPrefix(ref givenUnit);
        var targetUnitPrefix = GetPrefix(ref targetUnit);
        if (givenUnit.Contains("bit"))
        {
            unit = new BitUnit(value, givenUnitPrefix);
        }
        else if (givenUnit.Contains("byte"))
        {
            unit = new ByteUnit(value, givenUnitPrefix);
        }
        
        BaseUnit? convertedUnit = null;
        
        if (targetUnit.Contains("bit"))
        {
            var unitConverterInterface = unit as IConvertibleTo<BitUnit>;
            var bitUnit = new BitUnit(targetUnitPrefix);
            unitConverterInterface?.Convert(ref bitUnit);
            convertedUnit = bitUnit;
        }
        else if (targetUnit.Contains("byte"))
        {
            var unitConverterInterface = unit as IConvertibleTo<ByteUnit>;
            var byteUnit = new ByteUnit(targetUnitPrefix);
            unitConverterInterface?.Convert(ref byteUnit);
            convertedUnit = byteUnit;
        }
        else throw new NoConversionException();
        return convertedUnit?.PrintString();
    }

    private static string[] SplitString(string str)
    {
        return str.Split(new char[] {' ','\t'}, StringSplitOptions.RemoveEmptyEntries);
    }

    private static double ExtractValue(string number)
    {
        return double.Parse(number, System.Globalization.CultureInfo.InvariantCulture); 
    }

    private static UnitPrefix GetPrefix(ref string unitWithPrefix)
    {
        UnitPrefix prefix = UnitPrefix.EMPTY;
        if (unitWithPrefix.Contains("deca")) prefix = UnitPrefix.DECA;
        else if (unitWithPrefix.Contains("hecto")) prefix = UnitPrefix.HECTO;
        else if (unitWithPrefix.Contains("kilo")) prefix = UnitPrefix.KILO;
        else if (unitWithPrefix.Contains("mega")) prefix = UnitPrefix.MEGA;
        else if (unitWithPrefix.Contains("giga")) prefix = UnitPrefix.GIGA;
        else if (unitWithPrefix.Contains("tera")) prefix = UnitPrefix.TERA;
        else if (unitWithPrefix.Contains("peta")) prefix = UnitPrefix.PETA;
        else if (unitWithPrefix.Contains("exa")) prefix = UnitPrefix.EXA;
        else if (unitWithPrefix.Contains("zetta")) prefix = UnitPrefix.ZETTA;
        else if (unitWithPrefix.Contains("yotta")) prefix = UnitPrefix.YOTTA;
        return prefix;
    }
    
    private static bool TryParseLength(ref string valueWithUnit, ref string targetUnit, ref string givenUnit, ref double value)
    {
        if(!Regex.IsMatch(valueWithUnit, @"^\s*[0-9]*.{0,1}[0-9]+\s+(kilo|deca|hecto|mega|giga|tera|peta|exa|zetta|yotta){0,1}(meter|feet|inch)") ||
           !Regex.IsMatch(targetUnit, @"^\s*(kilo|deca|hecto|mega|giga|tera|peta|exa|zetta|yotta){0,1}(meter|feet|inch)")) return false;
        var strs = SplitString(valueWithUnit);
        value = ExtractValue(strs[0]);
        givenUnit = strs[1];
        return true;
    }
    
    private static bool TryParseData(ref string valueWithUnit, ref string targetUnit, ref string givenUnit, ref double value)
    {
        if(!Regex.IsMatch(valueWithUnit, @"^\s*[0-9]*.{0,1}[0-9]+\s+(kilo|deca|hecto|mega|giga|tera|peta|exa|zetta|yotta){0,1}(byte|bit)") ||
            !Regex.IsMatch(targetUnit, @"^\s*(kilo|deca|hecto|mega|giga|tera|peta|exa|zetta|yotta){0,1}(byte|bit)")) return false;
        var strs = SplitString(valueWithUnit);
        value = ExtractValue(strs[0]);
        givenUnit = strs[1];
        return true;
    }
    
    private static bool TryParseTemperature(ref string valueWithUnit, ref string targetUnit, ref string givenUnit, ref double value)
    {
        if(!Regex.IsMatch(valueWithUnit, @"^\s*[0-9]*.{0,1}[0-9]+\s+(celsius|fahrenheit)") ||
            !Regex.IsMatch(targetUnit, @"^\s*(celsius|fahrenheit)")) return false;
        var strs = SplitString(valueWithUnit);
        value = ExtractValue(strs[0]);
        givenUnit = strs[1];
        return true;
    }
}