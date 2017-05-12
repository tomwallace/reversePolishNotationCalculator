namespace ReversePolishNotation.Operations
{
    public interface IOperation
    {
        bool IsApplicable(string op);

        double Calculate(double a, double b);
    }
}