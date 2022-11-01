namespace Converters;



/*
 * Note: I can add here another prefixes such as cm, mm etc. But I should set their power of 10 into their num. And add them into base class printer and add to parser.
 */
public enum UnitPrefix
{
    //CENTI = -1,
    EMPTY = 0,
    DECA = 1,
    HECTO = 2,
    KILO = 3,
    MEGA = 6,
    GIGA = 9,
    TERA = 12,
    PETA = 15,
    EXA = 18,
    ZETTA = 21,
    YOTTA = 24
}