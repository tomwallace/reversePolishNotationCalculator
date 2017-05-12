using System;

namespace ReversePolishNotation.Operations
{
    public class PowerOperation : IOperation
    {
        public bool IsApplicable(string op)
        {
            return op == "^";
        }

        public double Calculate(double a, double b)
        {
            return Math.Pow(a, b);
        }
    }
}