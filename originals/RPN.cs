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


    public class RPN
    {
        public void Into(double new_data)
        {
            StackNode new_node = new StackNode(new_data, top);
            top = new_node;
        }

        public double OutOf()
        {
            double top_data = top.data;
            top = top.underneath;
            return top_data;
        }

        public RPN(String command)
        {
            top = null;
            this.command = command;
        }

        public double Get()
        {
            double a, b;
            int j;

            for (int i = 0; i < command.Length; i++)
            {                
                if (char.IsDigit(command[i]))
                {
                    double number;

                    // get a string of the number
                    string temp = "";
                    for (j = 0; (j < 100) && (char.IsDigit(command[i]) || (command[i] == '.')); j++, i++)
                    {
                        temp = string.Concat(temp, command[i]);
                    }

                    // convert to double and add to the stack
                    number = Double.Parse(temp);
                    Into(number);
                }
                else if (command[i] == '+')
                {
                    b = OutOf();
                    a = OutOf();
                    Into(a + b);
                }
                else if (command[i] == '-')
                {
                    b = OutOf();
                    a = OutOf();
                    Into(a - b);
                }
                else if (command[i] == '*')
                {
                    b = OutOf();
                    a = OutOf();
                    Into(a * b);
                }
                else if (command[i] == '/')
                {
                    b = OutOf();
                    a = OutOf();
                    Into(a / b);
                }
                else if (command[i] == '^')
                {
                    b = OutOf();
                    a = OutOf();
                    Into(Math.Pow(a, b));
                }
                else if (command[i] != ' ')
                {
                    throw new ArgumentException("Unrecognized character in expression");
                }
            }

            double val = OutOf();

            if (top != null)
            {
                throw new ArgumentException("Not enough tokens in expression");
            }

            return val;
        }

        private string command;
        private StackNode top;
    }