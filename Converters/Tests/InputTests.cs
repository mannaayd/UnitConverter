using NUnit.Framework;
using Converters;

namespace Converters.Tests;

public class InputTests
{
    [Test]
    public void LengthUnits()
    {
        Assert.AreEqual("0.001 kilometer", Converters.InputHandler.HandleInput("1 meter", "kilometer"));
    }

    [Test]
    public void BadGivenUnitInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.InputHandler.HandleInput("12 metter", "kilometer"));
    }
    
    [Test]
    public void BadGivenValueInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.InputHandler.HandleInput("1gg2 meter", "kilometer"));
    }
    
    [Test]
    public void BadTargetUnitInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.InputHandler.HandleInput("12 meter", "fsdsa"));
    }
    
    [Test]
    public void BadUnitPairInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.InputHandler.HandleInput("12 meter", "bytes"));
    }
    
    [Test]
    public void BadUnitPrefixInput()
    {
        Assert.Throws<InvalidInputException>(() => Converters.InputHandler.HandleInput("12 meter", "killometer"));
    }
}