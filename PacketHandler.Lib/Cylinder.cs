namespace PacketHandler.Lib;

public class Cylinder
{
    private float _length;
    public float Length
    {
        get { return _length; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Length cannot be negative.");
            }
            _length = value;
        }
    }


    public float Radius { get; set; }

    public float Weight { get; set; }

    public float GetPrice()
    {
        throw new NotImplementedException();
    }

    public float GetVolume()
    {
        throw new NotImplementedException();
    }
}