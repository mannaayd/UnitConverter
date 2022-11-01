using NUnit.Framework;

namespace Converters.Tests;

internal sealed class OutputTests
{
    [Test]
    public void TestConsoleOutput()
    {
        UnitConverter.Convert("34 celsius", "fahrenheit");
    }

    [Test]
    public void CelsiusToFahrenheit()
    {
        Assert.AreEqual("93,200 fahrenheit", UnitParser.ConvertStrings("34 celsius", "fahrenheit"));
    }
    
    [Test]
    public void FahrenheitToCelsius()
    {
        Assert.AreEqual("18,889 celsius", UnitParser.ConvertStrings("66 fahrenheit", "celsius"));
    }

    [Test]
    public void LengthUnits()
    {
        Assert.AreEqual("0,001 kilometer", Converters.UnitParser.ConvertStrings("1.0 meter", "kilometer"));
    }

    [Test]
    public void KilobyteToMegabit()
    {
        Assert.AreEqual("0,272 megabit", UnitParser.ConvertStrings("34 kilobyte", "megabit"));
    }
    
    [Test]
    public void KilobitToDecabyte()
    {
        Assert.AreEqual("425,000 decabyte", UnitParser.ConvertStrings("34 kilobit", "decabyte"));
    }

    [Test]
    public void MeterToFeet()
    {
        Assert.AreEqual("3,281 feet", UnitParser.ConvertStrings("1 meter", "feet"));
    }
    
    [Test]
    public void KilometerToInch()
    {
        Assert.AreEqual("39370,079 inch", UnitParser.ConvertStrings("1 kilometer", "inch"));
    }
}