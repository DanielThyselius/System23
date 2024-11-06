namespace Calculator.Tests;
using Lib;
public class CalculatorFixture
{
    public Calculator Default { get; set; }

    public CalculatorFixture()
    {
        Default = new Calculator();
    }
}