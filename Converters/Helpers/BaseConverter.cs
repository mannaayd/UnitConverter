namespace Converters;

public abstract class BaseConverter
{
    public abstract void Convert(ref BaseUnit unit1, ref BaseUnit unit2);
}