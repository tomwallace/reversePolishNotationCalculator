using System;
using System.Collections.Generic;

namespace ReversePolishNotation.Operations
{
    public class InvalidOperation : IOperation
    {
        // Include space so do not throw error incorrectly
        private List<string> validOperators = new List<string>() { "+", "-", "*", "/", "^" };

        public bool IsApplicable(string op)
        {
            if (!validOperators.Contains(op))
                throw new ArgumentException("Unrecognized character in expression");

            return false;
        }

        public double Calculate(double a, double b)
        {
            throw new NotImplementedException();
        }
    }
}