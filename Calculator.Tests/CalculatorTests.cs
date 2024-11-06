namespace Calculator.Tests;

using Calculator.Lib;

public class CalculatorTests :IClassFixture<CalculatorFixture>
{
    private readonly Calculator _sut;
    public CalculatorTests(CalculatorFixture fixture)
    {
        _sut = fixture.Default;
    }

    [Fact]
    public void DefaultNameIsDaniel()
    {
        // Arrange
        var sut = new Calculator();

        // Act
        // Assert
        Assert.Equal("Daniel", sut.Name);
    }
    
    [Fact]
    public void CanChangeName()
    {
        // Arrange
        var expected = "Ruben";
        // Act
        _sut.Name = expected;
        // Assert
        Assert.Equal(expected, _sut.Name);
    }
    
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(0, 3, 3)]
    [InlineData(0, 0, 0)]
    [InlineData(-5, 5, 0)]
    [InlineData(-1, 2, 1)]
    public void CanAdd(int a, int b, int expected)
    {
        // Arrange
        // Act
        var actual = _sut.Add(a, b);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CanDivideTenByTwo()
    {
        // Arrange
        var expected = 5;
        
        // Act
        var actual = _sut.Divide(10, 2);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ThrowsExceptionWhenDivideByZero()
    {
        Assert.Throws<DivideByZeroException>(() => _sut.Divide(2, 0));
    }

    [Fact]
    public void CanSubtractTenFromZero()
    {
        // Arrange
        var expected = -10;
        
        // Act
        float actual = _sut.Subtract(0f, 10f);

        // Assert
        Assert.Equal(expected, actual);
    }
}