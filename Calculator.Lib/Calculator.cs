namespace Calculator.Lib;

public class Calculator
{
    public string Name { get; set; } = "Daniel";


    public float Add(float a, float b)
    {
        return a + b;
    }

    public float Divide(float a, float b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        return a / b; 
    }

    public float Subtract(float f, float f1)
    {
        throw new NotImplementedException();
    }
}