using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReversePolishNotation.Operations
{
    public class OperationFactory
    {
        public IOperation Create(string character)
        {
            List<IOperation> operations = FindAllOperationsByInterface();
            foreach (IOperation op in operations)
            {
                if (op.IsApplicable(character))
                {
                    return op;
                }
            }

            throw new ArgumentException("Character passed was not handled by the operations.");
        }

        // Finds all types that implement the IOperation interface
        private List<IOperation> FindAllOperationsByInterface()
        {
            var instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                            where t.GetInterfaces().Contains(typeof(IOperation))
                            select Activator.CreateInstance(t) as IOperation;

            return instances.ToList();
        }
    }
}