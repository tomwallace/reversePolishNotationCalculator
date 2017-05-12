namespace ReversePolishNotation.Operations
{
    public class MultiplyOperation : IOperation
    {
        public bool IsApplicable(string op)
        {
            return op == "*";
        }

        public double Calculate(double a, double b)
        {
            return a * b;
        }
    }
}