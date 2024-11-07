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
    
    // Om längsta sidan <= 30 cm, och vikt max 20kg gäller detta:
    // 0-2 kg, 29 kr,
    // 3-9 kg, 49 kr,
    // 10-20 kg, 79 kr
    //    
    // Annas gäller:
    // Kortaste sidan (cm) x längsta sidan (cm) x vikt (kg) + 10000 = pris i öre.


    [Theory]
    // Small packets (<= 30)
    [InlineData(30, 30, 30, 0, 29)]
    [InlineData(30, 30, 30, 1, 29)]
    [InlineData(1, 1, 1, 1, 29)]
    [InlineData(0, 0, 0, 1, 29)]
    [InlineData(30, 30, 30, 2, 29)]
    [InlineData(30, 30, 30, 3, 49)]
    [InlineData(30, 30, 30, 9, 49)]
    [InlineData(30, 30, 30, 10, 79)]
    [InlineData(30, 30, 30, 20, 79)]
    [InlineData(30, 30, 30, 50, 550)]
    // Large packets
    [InlineData(31, 10, 10, 10, 131)]
    [InlineData(10, 31, 10, 10, 131)]
    [InlineData(10, 10, 31, 10, 131)]
    [InlineData(10, 10, 50, 1, 105)]
    [InlineData(10, 10, 50, 0, 100)]
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