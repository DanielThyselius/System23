using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

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
        var mockDb = new Mock<IDatabase>();
        mockDb.Setup(x => x.GetItemPrice(It.IsAny<string>())).Returns(10);
        var mockDateTimeProvider = new Mock<IDateTimeProvider>();
        mockDateTimeProvider.Setup(x => x.Now).Returns(DateTime.Parse("2024-01-05T12:00:00"));
        var sut = new ReceiptGenerator(item, quantity, mockDb.Object, mockDateTimeProvider.Object);

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
        //TODO: use Moq!
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
//
// class TestDatabase : IDatabase
// {
//     public float GetItemPrice(string id) => 10;
// }
//
// class TestDateTimeProvider : IDateTimeProvider
// {
//     public DateTime Now => DateTime.Parse("2024-01-05T12:00:00");
// }
