using System.Text;
using System.Text.RegularExpressions;

namespace Converters;

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