namespace Converters;

public static class DataConverters 
{
    public static void Convert(ref BitUnit bit1, ref BitUnit bit2)
    {
        bit2.SetValueWithPrefix(bit1.GetValueWithoutPrefix());
    }
    
    public static void Convert(ref ByteUnit byte1, ref ByteUnit byte2)
    {
        byte2.SetValueWithPrefix(byte1.GetValueWithoutPrefix());
    }
    
    public static void Convert(ref ByteUnit byte1, ref BitUnit bit)
    {
        bit.SetValueWithPrefix(Decimal.Multiply(byte1.GetValueWithoutPrefix(), 8m));
    }
    
    public static void Convert(ref BitUnit bit, ref ByteUnit byte1)
    {
        byte1.SetValueWithPrefix(Decimal.Divide(bit.GetValueWithoutPrefix(), 8m));
    }
}