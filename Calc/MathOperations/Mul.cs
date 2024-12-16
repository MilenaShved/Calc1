using Calc.CommandsInterface;

namespace Calc.MathOperations
{
    public class Mul : IOp
    {
        public double Apply(double a, double b) => a * b;
        public string Sym => "*";
    }
}
