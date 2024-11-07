namespace PacketHandler.Test;

public class TestData
{
    public static IEnumerable<object[]> CylinderVolumeTestData()
    {
        
        var list = new List<object[]>
        {
            new object[] { 1, 5, 15.707963267948966192313216916398},
            new object[] { 2, 7, 87.964594300514210676954014731826},
            new object[] { 3, 3, 84.823001646924417438491371348547 }
        };
        
        return list;
    }

    public static IEnumerable<object[]> FromCsv()
    {
        var lines = File.ReadAllLines("testData.csv");
        var list = new List<object[]>();
        foreach (var line in lines)
        {
            var values = line.Split(',');
            list.Add([int.Parse(values[0]), int.Parse(values[1])]);
        }

        return list;
    }
    
    public static IEnumerable<object[]> BlockTestData =>
        new List<object[]>
        {
            new object[] { 20, 20, 20, 8000 },
            new object[] { 10, 5, 20, 1000 },
            new object[] { 0, 20, 20, 0 },
            new object[] { 20, 0, 20, 0 },
            new object[] { 20, 20, 0, 0 },
        };
}
