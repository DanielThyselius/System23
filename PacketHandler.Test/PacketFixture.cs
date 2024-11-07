using PacketHandler.Lib;

namespace PacketHandler.Test;

public class PacketFixture 
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