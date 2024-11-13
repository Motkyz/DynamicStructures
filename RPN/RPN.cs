using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructures.RPN
{
    public class RPN
    {
        public double Result = 0;
        public string Rpn = string.Empty;
        public string Input = string.Empty;
        public RPN(string input)
        {
            this.Input = input;
            List<object> rpnList = TransformToRPNForm(GetObjects(input));
            Rpn = string.Join(" ", rpnList);
            Result = CalculateRPN(rpnList);
        }

        public static List<object> GetObjects(string input)
        {
            input = input.Replace(" ", string.Empty).ToLower();

            List<object> objects = new List<object>();
            string buffer = string.Empty;

            foreach (char symbol in input)
            {
                if (Char.IsDigit(symbol) || symbol == ',' || symbol == '.')
                {
                    buffer += symbol;
                }
                else if (Char.IsLetter(symbol))
                {
                    buffer += symbol;
                }
                else
                {
                    if (buffer != string.Empty)
                    {
                        objects.Add(buffer);
                    }
                    objects.Add(symbol);

                    buffer = string.Empty;
                }
            }

            if (buffer != string.Empty)
            {
                objects.Add(buffer);
            }

            return objects;
        }
        public static List<object> TransformToRPNForm(List<object> objects)
        {
            List<object> rpnList = new List<object>();
            MyStack<string> opers = new();

            foreach (object obj in objects)
            {
                string o = obj.ToString();
                if (Double.TryParse(o, out double number))
                {
                    rpnList.Add(number);
                }
                else if (o == "(" || o == ")")
                {
                    if (o == "(")
                    {
                        opers.Push(o);
                    }

                    else
                    {
                        while (opers.Top().ToString() != "(")
                        {
                            rpnList.Add(opers.Pop());
                        }   
                        opers.Pop();
                    }
                }
                else if (IsOperation(o))
                {
                    if (opers.Count != 0 && IsOperation(opers.Top().ToString()))
                    {
                        if (GetPriority(opers.Top().ToString()) >= GetPriority(o))
                        {
                            rpnList.Add(opers.Pop().ToString());
                            opers.Push(o);
                        }
                        else opers.Push(o);
                    }
                    else opers.Push(o);
                }
                else
                {
                    throw new Exception("Invalid Token");
                }
            }

            while (opers.Count != 0)
            {
                rpnList.Add(opers.Pop().ToString());
            }

            return rpnList;
        }

        private static byte GetPriority(string s)
        {
            return s switch
            {
                "+" => 0,
                "-" => 0,
                "*" => 1,
                "/" => 1,
                "^" => 2,
                "sqrt" => 3,
                "sin" => 3,
                "cos" => 3,
                "ln" => 3,
                _ => 6,
            };
        }

        private static double CalculateRPN(List<object> rpn)
        {
            if (rpn.Count == 0)
                throw new ArgumentException("error: нет выражения");

            MyStack<double> calc = new();
            foreach (var element in rpn)
            {
                double.TryParse(element.ToString(), out double doubleValue);
                if (doubleValue != 0)
                {
                    calc.Push(doubleValue);
                }
                else if (IsOperation(element.ToString()))
                {
                    if (element.ToString() == "sin" || element.ToString() == "cos" || element.ToString() == "ln" || element.ToString() == "sqrt")
                    {
                        double first = calc.Pop();
                        calc.Push(CalculateOperation(first: first, operation: element.ToString()));
                    }
                    else
                    {
                        double second = calc.Pop();
                        double first = calc.Pop();
                        calc.Push(CalculateOperation(first: first, second: second, operation: element.ToString()));
                    }
                }
                else
                    throw new ArgumentException("error: непонятное число");
            }

            return calc.Pop();
        }

        private static double CalculateOperation(double first, string operation, double second = 0)
        {
            return operation switch
            {
                "+" => first + second,
                "-" => first - second,
                "/" => first / second,
                "*" => first * second,
                "ln" => Math.Log(first),
                "cos" => Math.Cos(first),
                "sin" => Math.Sin(first),
                "sqrt" => Math.Sqrt(first),
                "^" => Math.Pow(first, second),
                _ => throw new Exception("error: такой операции не существует"),
            };
        }

        private static bool IsOperation(string operation)
        {
            return (operation.Equals("+") || operation.Equals("-") || operation.Equals("=") || operation.Equals("/") || operation.Equals("*")
        || operation.Equals("^") || operation.Equals("ln") || operation.Equals("cos") || operation.Equals("sin") || operation.Equals("sqrt"));
        }
    }
}
