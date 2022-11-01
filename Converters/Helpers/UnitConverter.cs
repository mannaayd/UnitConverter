using System.Text;
using System.Text.RegularExpressions;

namespace Converters;


/*
 *  Example input  (from X units, to target unit)-> output:
 *  ("1 meter", "feet") -> "3.28 feet"
 *  ("3 kiloinch", "meter") -> "76.19 meter"
 */
public static class UnitConverter
{
    /**
     * @brief Print to console output converted result
     * @throws NoConversionException in case there is no way to convert units
     * @throws InvalidInputException in case invalid input
     */
    public static void Convert(string valueWithUnit, string targetUnit)
    {
        Console.WriteLine(UnitParser.ConvertStrings(valueWithUnit, targetUnit));
    }

    
}