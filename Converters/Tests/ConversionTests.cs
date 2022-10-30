using NUnit.Framework;

namespace Converters.Tests;

public class ConversionTests
{
    [Test]
    public void CelsiusToFahrenheit()
    {
        CelsiusUnit celsius = new CelsiusUnit(34m);
        FahrenheitUnit fahrenheits = new FahrenheitUnit(0m);
        TemperatureConverters.Convert(ref celsius, ref fahrenheits);
        Assert.AreEqual( 93.2m, fahrenheits.Value);
    }
    
    [Test]
    public void FahrenheitToCelsius()
    {
        FahrenheitUnit fahrenheits = new FahrenheitUnit(50m);
        CelsiusUnit celsius = new CelsiusUnit(0m);
        TemperatureConverters.Convert(ref fahrenheits, ref celsius);
        Assert.AreEqual(10m, Decimal.Round(celsius.Value, 4));
    }

    [Test]
    public void FeetToInch()
    {
        FeetUnit feet = new FeetUnit(1m);
        InchUnit inch = new InchUnit(0m);
        LengthConverters.Convert(ref feet, ref inch);
        Assert.AreEqual(12m, inch.Value);
    }

    [Test]
    public void InchToFeet()
    {
        FeetUnit feet = new FeetUnit(0m);
        InchUnit inch = new InchUnit(24m);
        LengthConverters.Convert(ref inch, ref feet);
        Assert.AreEqual(2m, feet.Value);
    }

    [Test]
    public void InchToMeter()
    {
        InchUnit inch = new InchUnit(20m);
        MeterUnit meter = new MeterUnit(0m, SIUnitPrefix.EMPTY); // initializing meters
        LengthConverters.Convert(ref inch, ref meter);
        Assert.AreEqual(0.508m, meter.Value);
    }

    [Test]
    public void FeetToMeter()
    {
        FeetUnit feet = new FeetUnit(20m);
        MeterUnit meter = new MeterUnit(0m, SIUnitPrefix.EMPTY); // initializing meters
        LengthConverters.Convert(ref feet, ref meter);
        Assert.AreEqual(6.096m, meter.Value);
    }
    
    [Test]
    public void InchToKilometer()
    {
        InchUnit inch = new InchUnit(20000m);
        MeterUnit meter = new MeterUnit(0m, SIUnitPrefix.KILO); // initializing kilometers
        LengthConverters.Convert(ref inch, ref meter);
        Assert.AreEqual(0.508m, Decimal.Round(meter.Value, 4));
    }

    [Test]
    public void FeetToKilometer()
    {
        FeetUnit feet = new FeetUnit(240m);
        MeterUnit meter = new MeterUnit(0m, SIUnitPrefix.KILO); // initializing kilometers
        LengthConverters.Convert(ref feet, ref meter);
        Assert.AreEqual(0.0732m, Decimal.Round(meter.Value, 4));
    }
    
    [Test]
    public void MeterToKilometer()
    {
        MeterUnit meter1 = new MeterUnit(1000m, SIUnitPrefix.EMPTY); 
        MeterUnit meter2 = new MeterUnit(0m, SIUnitPrefix.KILO); // initializing kilometers
        LengthConverters.Convert(ref meter1, ref meter2);
        Assert.AreEqual(1m, Decimal.Round(meter2.Value, 4));
    }
    
    [Test]
    public void KilometerToKilometer()
    {
        MeterUnit meter1 = new MeterUnit(1000m, SIUnitPrefix.KILO); 
        MeterUnit meter2 = new MeterUnit(0m, SIUnitPrefix.KILO); // initializing kilometers
        LengthConverters.Convert(ref meter1, ref meter2);
        Assert.AreEqual(1000m, Decimal.Round(meter2.Value, 4));
    }

    [Test]
    public void BitsToBytes()
    {
        BitUnit bit = new BitUnit(64m, SIUnitPrefix.EMPTY);
        ByteUnit byte1 = new ByteUnit(0m, SIUnitPrefix.EMPTY);
        DataConverters.Convert(ref bit, ref byte1);
        Assert.AreEqual(8m, byte1.Value);
    }

    [Test]
    public void BytesToBits()
    {
        ByteUnit byte1 = new ByteUnit(64m, SIUnitPrefix.EMPTY);
        BitUnit bit = new BitUnit(0m, SIUnitPrefix.EMPTY);
        DataConverters.Convert(ref byte1, ref bit);
        Assert.AreEqual(512m, bit.Value);
    }

    [Test]
    public void BitsToKilobits()
    {
        BitUnit bit1 = new BitUnit(1000m, SIUnitPrefix.EMPTY);
        BitUnit bit2 = new BitUnit(0m, SIUnitPrefix.KILO);
        DataConverters.Convert(ref bit1, ref bit2);
        Assert.AreEqual(1m, bit2.Value);
    }

    [Test]
    public void BytesToKilobytes()
    {
        ByteUnit byte1 = new ByteUnit(1024m, SIUnitPrefix.EMPTY);
        ByteUnit byte2 = new ByteUnit(0m, SIUnitPrefix.KILO);
        DataConverters.Convert(ref byte1, ref byte2);
        Assert.AreEqual(1.024m, byte2.Value);
    }

    [Test]
    public void KilobytesToKilobits()
    {
        ByteUnit byte1 = new ByteUnit(128m, SIUnitPrefix.KILO);
        BitUnit bit = new BitUnit(0m, SIUnitPrefix.KILO);
        DataConverters.Convert(ref byte1, ref bit);
        Assert.AreEqual(1024m, bit.Value);
    }
}