using System.Text.RegularExpressions;
using NUnit.Framework;
using Converters;

namespace Converters.Tests;

internal class InputTests
{

    [Test]
    public void GoodGivenUnitInput()
    {
        Assert.DoesNotThrow(() => Converters.UnitConverter.Convert("12 meter", "kilometer"));
    }
    
    [Test]
    public void BadGivenUnitInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.UnitConverter.Convert("12 metter", "kilometer"));
    }
    
    [Test]
    public void BadGivenValueInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.UnitConverter.Convert("1gg2 meter", "kilometer"));
    }
    
    [Test]
    public void BadTargetUnitInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.UnitConverter.Convert("12 meter", "fsdsa"));
    }
    
    [Test]
    public void BadUnitPairInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.UnitConverter.Convert("12 meter", "bytes"));
    }
    
    [Test]
    public void BadUnitPrefixInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.UnitConverter.Convert("12 meter", "killometer"));
    }


}