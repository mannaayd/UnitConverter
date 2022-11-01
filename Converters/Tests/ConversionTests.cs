using NUnit.Framework;

namespace Converters.Tests;

public class ConversionTests
{
    [Test]
    public void CelsiusToFahrenheit()
    {
        CelsiusUnit Celsius = new CelsiusUnit(34);
        FahrenheitUnit fahrenheits = new FahrenheitUnit(0);
        Celsius.Convert(ref fahrenheits);
        Assert.AreEqual( 93.2, fahrenheits.Value);
    }
    
    [Test]
    public void FahrenheitToCelsius()
    {
        FahrenheitUnit fahrenheits = new FahrenheitUnit(50);
        CelsiusUnit celsius = new CelsiusUnit(0);
        fahrenheits.Convert(ref celsius);
        Assert.AreEqual(10, Math.Round(celsius.Value, 2));
    }

    [Test]
    public void FeetToInch()
    {
        FeetUnit feet = new FeetUnit(1, UnitPrefix.EMPTY);
        InchUnit inch = new InchUnit(0, UnitPrefix.EMPTY);
        feet.Convert(ref inch);
        Assert.AreEqual(12, inch.Value);
    }

    [Test]
    public void InchToFeet()
    {
        FeetUnit feet = new FeetUnit(0, UnitPrefix.EMPTY);
        InchUnit inch = new InchUnit(24, UnitPrefix.EMPTY);
        inch.Convert(ref feet);
        Assert.AreEqual(2, feet.Value);
    }

    [Test]
    public void InchToMeter()
    {
        InchUnit inch = new InchUnit(20, UnitPrefix.EMPTY);
        MeterUnit meter = new MeterUnit(0, UnitPrefix.EMPTY); // initializing meters
        inch.Convert(ref meter);
        Assert.AreEqual(0.508, meter.Value);
    }

    [Test]
    public void FeetToMeter()
    {
        FeetUnit feet = new FeetUnit(20, UnitPrefix.EMPTY);
        MeterUnit meter = new MeterUnit(0, UnitPrefix.EMPTY); // initializing meters
        feet.Convert(ref meter);
        Assert.AreEqual(6.096, meter.Value);
    }
    
    [Test]
    public void InchToKilometer()
    {
        InchUnit inch = new InchUnit(20000, UnitPrefix.EMPTY);
        MeterUnit meter = new MeterUnit(0, UnitPrefix.KILO); // initializing kilometers
        inch.Convert(ref meter);
        Assert.AreEqual(0.508, meter.Value);
    }

    [Test]
    public void FeetToKilometer()
    {
        FeetUnit feet = new FeetUnit(240, UnitPrefix.EMPTY);
        MeterUnit meter = new MeterUnit(0, UnitPrefix.KILO); // initializing kilometers
        feet.Convert(ref meter);
        Assert.AreEqual(0.0732, meter.Value, 0.0001);
    }
    
    [Test]
    public void MeterToKilometer()
    {
        MeterUnit meter1 = new MeterUnit(1000, UnitPrefix.EMPTY); 
        MeterUnit meter2 = new MeterUnit(0, UnitPrefix.KILO); // initializing kilometers
        meter1.Convert(ref meter2);
        Assert.AreEqual(1, meter2.Value);
    }
    
    [Test]
    public void KilometerToKilometer()
    {
        MeterUnit meter1 = new MeterUnit(1000, UnitPrefix.KILO); 
        MeterUnit meter2 = new MeterUnit(0, UnitPrefix.KILO); // initializing kilometers
        meter1.Convert(ref meter2);
        Assert.AreEqual(1000, meter2.Value);
    }

    [Test]
    public void BitsToBytes()
    {
        BitUnit bit = new BitUnit(64, UnitPrefix.EMPTY);
        ByteUnit byte1 = new ByteUnit(0, UnitPrefix.EMPTY);
        bit.Convert(ref byte1);
        Assert.AreEqual(8, byte1.Value);
    }

    [Test]
    public void BytesToBits()
    {
        ByteUnit byte1 = new ByteUnit(64, UnitPrefix.EMPTY);
        BitUnit bit = new BitUnit(0, UnitPrefix.EMPTY);
        byte1.Convert(ref bit);
        Assert.AreEqual(512, bit.Value);
    }

    [Test]
    public void BitsToKilobits()
    {
        BitUnit bit1 = new BitUnit(1000, UnitPrefix.EMPTY);
        BitUnit bit2 = new BitUnit(0, UnitPrefix.KILO);
        bit1.Convert(ref bit2);
        Assert.AreEqual(1, bit2.Value);
    }

    [Test]
    public void BytesToKilobytes()
    {
        ByteUnit byte1 = new ByteUnit(1024, UnitPrefix.EMPTY);
        ByteUnit byte2 = new ByteUnit(0, UnitPrefix.KILO);
        byte1.Convert(ref byte2);
        Assert.AreEqual(1.024, byte2.Value);
    }

    [Test]
    public void KilobytesToKilobits()
    {
        ByteUnit byte1 = new ByteUnit(128, UnitPrefix.KILO);
        BitUnit bit = new BitUnit(0, UnitPrefix.KILO);
        byte1.Convert(ref bit);
        Assert.AreEqual(1024, bit.Value);
    }

    [Test]
    public void KiloinchToMeter()
    {
        InchUnit inch = new InchUnit(3, UnitPrefix.KILO);
        MeterUnit meter = new MeterUnit(UnitPrefix.EMPTY);
        inch.Convert(ref meter);
        Assert.AreEqual(76.19, meter.Value, 0.1);
    }

    [Test]
    public void MeterToFeet()
    {
        MeterUnit meter = new MeterUnit(1, UnitPrefix.EMPTY);
        FeetUnit feet = new FeetUnit(UnitPrefix.EMPTY);
        meter.Convert(ref feet);
        Assert.AreEqual(3.28, Math.Round(feet.Value, 2));
    }
}