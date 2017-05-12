namespace ReversePolishNotation
{
    public class StackNode
    {
        public StackNode(double data, StackNode underneath)
        {
            this.data = data;
            this.underneath = underneath;
        }

        public StackNode underneath;
        public double data;
    }
}