namespace Calculator.Tests;
using Calculator.Lib;

public class CalculatorTests
{
    [Fact]
    public void CanAddTwoPlusThree()
    {
        // Arrange
        var calc = new Calculator();
        var expected = 5;
        
        // Act
        var actual = calc.Add(2, 3);

        // Assert
        // Assert.Throws<Exception>(()=> calc.Add(0, expected));
        Assert.Equal(expected, actual);
        Assert.Equal("Bob", calc.Name);
    }
}