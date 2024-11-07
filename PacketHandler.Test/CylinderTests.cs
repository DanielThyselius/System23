using System.Collections;
using PacketHandler.Lib;

namespace PacketHandler.Test;

public class CylinderTests : IClassFixture<PacketFixture>
{
    private readonly PacketFixture _fixture;

    public CylinderTests(PacketFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ThrowsExceptionOnSettingNegativeDimensions()
    {
        // Arrange
        var sut = _fixture.NormalCylinder;

        // Act
        // Assert
        Assert.ThrowsAny<ArgumentOutOfRangeException>(() => sut.Length = -1);
        Assert.ThrowsAny<ArgumentOutOfRangeException>(() => sut.Radius = -1);
    }

    [Theory]
    [MemberData(nameof(TestData.CylinderVolumeTestData), MemberType = typeof(TestData))]
    public void CalculatesVolumeCorrectly(float radius, float length, float expected)
    {
        // Arrange
        var sut = _fixture.NormalCylinder;
        sut.Radius = radius;
        sut.Length = length;

        // Act
        var actual = sut.GetVolume();

        // Assert
        Assert.Equal(expected, actual);
    }


    [Theory]
    [ClassData(typeof(CylinderTestData))]
    public void CanCalculatePrice(float radius, float length, int weight, float expected)
    {
        // Arrange
        var sut = _fixture.NormalCylinder;
        sut.Radius = radius;
        sut.Length = length;
        sut.Weight = expected;
        
        // Act
        var actual = sut.GetPrice();

        // Assert
        Assert.Equal(expected, actual);
    }

    // This test is stupid, but it's just to show that you can use MemberData
    [Theory]
    [MemberData(nameof(TestData.FromCsv), MemberType = typeof(TestData))]
    public void TestDataWorks(int a, int b)
    {
        Assert.Equal(a*2, b);
    }
}

public class CylinderTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        var list = new List<object[]>()
        {
            new object[] { 1, 1, 1, 1 },
            new object[] { 2, 2, 2, 2 },
        };
        return list.GetEnumerator();
        
        // TODO: Extraövning för att förstå IEnumerable
        // Skapa en klass som implementerar IEnumerable<int> och returnear 
        // de natuliga talen från 1 till 1000.
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
