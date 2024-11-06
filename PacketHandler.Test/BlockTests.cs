using PacketHandler.Lib;

namespace PacketHandler.Test;

public class BlockTests
{
    [Theory]
    [InlineData(20, 20, 20, 8000)]
    [InlineData(10, 5, 20, 1000)]
    [InlineData(0, 20, 20, 0)]
    [InlineData(20, 0, 20, 0)]
    [InlineData(20, 20, 0, 0)]
    public void CalculatesCorrectVolume(int length, int width, int height, int expected)
    {
        // Arrange
        var sut = new Block();

        sut.Height = height;
        sut.Width = width;
        sut.Length = length;

        // Act
        var actual = sut.GetVolume();

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(-1, 1, 1)]
    [InlineData(1, -1, 1)]
    [InlineData(1, 1, -1)]
    [InlineData(-1, -1, -1)]    
    [InlineData(1, -1, -1)]
    [InlineData(-1, -1, 1)]
    [InlineData(-1, 1, -1)]
    public void ThrowsExceptionOnNegativeDimensions(int length, int width, int height)
    {
        // Arrange
        var sut = new Block();

        sut.Height = height;
        sut.Width = width;
        sut.Length = length;

        // Act
        // Assert
        Assert.ThrowsAny<ArgumentOutOfRangeException>(() => sut.GetVolume());
    }
    // Kortaste sidan (cm) x längsta sidan (cm) x vikt (kg) + 10000 = pris i öre. 
    // 
    // plus detta:
    //
    // Om längsta sidan < 30 cm och upp till 2 kg, 29 kr,
    // och 2-9 kg, 49 kr,
    // och 10-20 kg, 79 kr

    // TODO: verify price logic above
    [Theory]
    [InlineData(10, 10, 10, 1, 130)]
    [InlineData(40, 10, 10, 1, 153)]
    [InlineData(40, 10, 10, 10, 219 )]
    public void CalculatesCorrectPrice(int length, int width, int height, int weight, int expected)
    {
        // Arrange
        var sut = new Block();
        sut.Height = height;
        sut.Width = width;
        sut.Length = length;
        sut.Weight = weight;
        
        // Act
        var actual = sut.GetPrice();
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
}