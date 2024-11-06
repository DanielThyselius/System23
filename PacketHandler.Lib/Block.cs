namespace PacketHandler.Lib;

public class Block
{
    public int Height { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }

    public int Weight { get; set; }

    public float GetPrice()
    {
        throw new NotImplementedException();
    }

    public float GetVolume()
    {
        if (Length < 0 || Height < 0 || Width < 0)
        {
            throw new ArgumentOutOfRangeException("Length and height and width must be non-negative.");
        }
        return Height * Width * Length;
    }
}