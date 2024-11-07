namespace PacketHandler.Lib;

public class Block
{
    public int Height { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }

    public int Weight { get; set; }

    public float GetPrice()
    {
        // If packet is outside of size limits
        if (Length > 30 || Height > 30 || Width > 30 || Weight > 20)
        {
            var min = Math.Min(Math.Min(Length, Height), Width);
            var max = Math.Max(Math.Max(Length, Height), Width);
            
            // price is in öre
            var price = min * max * Weight + 10000;

            // return in sek
            // ReSharper disable once PossibleLossOfFraction
            return price / 100;
        }

        return Weight switch
        {
            <= 2 => 29,
            <= 9 => 49,
            _ => 79
        };

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