using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BadProgram.Test;

public class UnitTest1
{
    [Fact]
    public void ReceiptGeneratesCorrectly()
    {
        // Arrange
        var item = "Sko";
        var price = 10f;
        var quantity = 3;
        var discount = 10;
        var total = 27;
        var date = DateTime.Parse("2024-01-01T12:00:00");
        var sut = new ReceiptGenerator(price, quantity, discount);

        var expected = """
                        ********************************
                        KVITTO
                        Sko(10.00) x 3
                        rabatt: 10%
                        Total price: 27:-
                        ~~~~~~~~~~~~~~~~~~~~~ 
                        2024-01-01 12:00:00
                        ********************************
                        """;
        // Act
        var actual = sut.Generate(item, total, date);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    // Test GetTotal
    [Fact]
    public void GetTotal()
    {
        // Arrange
        var price = 10f;
        var quantity = 3;
        var discount = 10;
        var sut = new ReceiptGenerator(price, quantity, discount);

        var expected = 27;
        // Act
        var actual = sut.GetTotal();

        // Assert
        Assert.Equal(expected, actual);
    }
    
}