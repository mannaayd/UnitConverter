namespace Converters;

public static class LengthConverters
{
    public static void Convert(ref MeterUnit meters, ref InchUnit inches)
    {
        inches.Value = Decimal.Divide(meters.GetValueWithoutPrefix(), 0.0254m);
    }

    public static void Convert(ref MeterUnit meters, ref FeetUnit feets)
    {
        feets.Value = Decimal.Multiply(meters.GetValueWithoutPrefix(), 3.280839895m);
    }

    public static void Convert(ref InchUnit inches, ref MeterUnit meters)
    {
       meters.SetValueWithPrefix(Decimal.Multiply(inches.Value, 0.0254m));
    }
    
    public static void Convert(ref FeetUnit feets, ref MeterUnit meters)
    {
        meters.SetValueWithPrefix(Decimal.Multiply(feets.Value, 0.3048m));
    }
    
    public static void Convert(ref InchUnit inches, ref FeetUnit feets)
    {
        feets.Value = Decimal.Divide(inches.Value, 12);
    }
    
    public static void Convert(ref FeetUnit feets, ref InchUnit inches)
    {
        inches.Value = Decimal.Multiply(feets.Value, 12);
    }
    
    public static void Convert(ref MeterUnit meters1, ref MeterUnit meters2)
    {
        meters2.SetValueWithPrefix(meters1.GetValueWithoutPrefix());
    }
}