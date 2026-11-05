using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class PostfixCalculator
    {
        public static string Calculate(string postfixExpression)
        {
            if (postfixExpression == "")
            {
                return "0";
            }

            var separators = new List<string> { "+", "*", "-" };
            var stack = new Stack<int>();
            var numbers = postfixExpression.Split();

            if (postfixExpression == null || 
            char.IsLetter(Convert.ToChar(postfixExpression)) ||
            !separators.Contains(numbers[numbers.Count() - 1]))
            {
                throw new FormatException();
            }
            
            for(var i = 0; i < numbers.Count(); i++)
            {
                if(numbers[i] == "+")
                {
                    if(stack.Count() < 2)
                    {
                        throw new FormatException();
                    }
                    var res = stack.Peek();
                    stack.Pop();
                    res += stack.Peek();
                    stack.Pop();
                    stack.Push(res);

                }
                if(numbers[i] == "-")
                {
                    if(stack.Count() < 2)
                    {
                        throw new FormatException();
                    }
                    var res = stack.Peek();
                    stack.Pop();
                    res -= stack.Peek();
                    stack.Pop();
                    stack.Push(res);
                }
                if(numbers[i] == "*")
                {
                    if(stack.Count() < 2)
                    {
                        throw new FormatException();
                    }
                    var res = stack.Peek();
                    stack.Pop();
                    res *= stack.Peek();
                    stack.Pop();
                    stack.Push(res);
                }
                else
                {
                    stack.Push(int.Parse(numbers[i]));
                }
            }

            if(stack.Count() != 1)
            {
                throw new FormatException();
            }
            
            return stack.Peek().ToString();
        }
    }
}
