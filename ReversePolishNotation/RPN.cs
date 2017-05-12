using System;
using System.Collections.Generic;
using System.Linq;
using ReversePolishNotation.Operations;

namespace ReversePolishNotation
{
    public class RPN
    {
        private StackNode _top;

        private readonly List<string> splitCommand;

        public void AddToStack(double new_data)
        {
            _top = new StackNode(new_data, _top);
        }

        public double PopOffStack()
        {
            double topData = _top.data;
            _top = _top.underneath;
            return topData;
        }

        public RPN(string command)
        {
            // If there are remaining nodes, then we did not have enough to evaluate
            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentException("Not enough tokens in expression");
            }

            _top = null;
            // Split off extra spaces
            splitCommand = command.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        public double Calculate()
        {
            foreach (string part in splitCommand)
            {
                double number;
                if (Double.TryParse(part, out number))
                {
                    AddToStack(number);
                }
                else
                {
                    IOperation operation = new OperationFactory().Create(part);
                    double b = PopOffStack();
                    double a = PopOffStack();
                    AddToStack(operation.Calculate(a, b));
                }
            }

            return PopOffStack();
        }
    }
}