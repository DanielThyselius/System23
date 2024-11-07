using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BadProgram.Test;

public class UnitTest1
{
    [Fact]
    public void ReceiptGeneratesCorrectly()
    {
        // Arrange
        var item = "Sko";
        var quantity = 3;
        var total = 27;
        var db = new TestDatabase();
        var datetimeProvider = new TestDateTimeProvider();
        var sut = new ReceiptGenerator(item, quantity, db, datetimeProvider);

        var expected = """
                        ********************************
                        KVITTO
                        Sko(10.00) x 3
                        rabatt: 10%
                        Total price: 27:-
                        ~~~~~~~~~~~~~~~~~~~~~ 
                        2024-01-05 12:00:00
                        ********************************
                        """;
        // Act
        var actual = sut.Generate(item, total);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    // Test GetTotal
    [Fact]
    public void GetTotal()
    {
        // Arrange
        var item = "Sko";
        var quantity = 3;
        var db = new TestDatabase();
        var datetimeProvider = new TestDateTimeProvider();
        var sut = new ReceiptGenerator(item, quantity, db, datetimeProvider);

        var expected = 27;
        // Act
        var actual = sut.GetTotal();

        // Assert
        Assert.Equal(expected, actual);
    }
}

class TestDatabase : IDatabase
{
    public float GetItemPrice(string id) => 10;
}

class TestDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Parse("2024-01-05T12:00:00");
}
