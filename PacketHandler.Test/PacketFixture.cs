using PacketHandler.Lib;

namespace PacketHandler.Test;

public class PacketFixture : IClassFixture<Cylinder>
{
    public Cylinder NormalCylinder { get; }

    public PacketFixture()
    {
        NormalCylinder = new Cylinder()
        {
            Radius = 1,
            Length = 1,
            Weight = 1
        };
    }
}