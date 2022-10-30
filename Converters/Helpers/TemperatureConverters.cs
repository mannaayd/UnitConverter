namespace Converters;

public static class TemperatureConverters
{
    public static void Convert(ref FahrenheitUnit fahrenheits, ref CelsiusUnit celsius)
    {
        celsius.Value = Decimal.Multiply(Decimal.Subtract(fahrenheits.Value, 32m), Decimal.Divide(5m, 9m));
    }

    public static void Convert(ref CelsiusUnit celsius, ref FahrenheitUnit fahrenheits)
    {
        fahrenheits.Value = Decimal.Add(Decimal.Multiply(celsius.Value, Decimal.Divide(9m, 5m)), 32m);
    }
}