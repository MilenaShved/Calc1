using System;
using Calc.CommandsInterface;

namespace Calc.MathOperations
{
    public class Div : IOp
    {
        public double Apply(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("деление на ноль невозможно");
            return a / b;
        }

        public string Sym => "/";
    }
}
