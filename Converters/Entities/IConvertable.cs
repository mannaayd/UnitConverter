namespace Converters;

public interface IConvertibleTo<T>
{
    /**
     * @brief Method that converts this.Value to t.Value of class T
     * @param[in/out] T t - already declared object, output object t should have converted Value
     */
    public void Convert(ref T t);
}