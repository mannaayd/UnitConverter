namespace Converters;

public class TemperatureConverters
{
    public static void Convert(ref CelsiusUnit celsius, out FahrenheitUnit fahrenheits)
    {
        fahrenheits = new FahrenheitUnit((decimal)(celsius.Value * (decimal)(9/5)) + 32);
    }

    public static void Convert(ref FahrenheitUnit fahrenheits, out CelsiusUnit celsius)
    {
        celsius = new CelsiusUnit((decimal)((fahrenheits.Value - 32) * (decimal)(5/9)));
    }
}