using System.Collections;
using System.Linq.Expressions;
using MyStackProj;
MyStack<double> stack = new MyStack<double>();

string expression = "5 2 + 3 *";

foreach (var token in expression.Split(' '))
{
    Console.WriteLine(token); // just to test
}

foreach (var token in expression.Split(' '))
{
    if (double.TryParse(token, out double num))
        stack.Push(num);
    else
    {
        double b = stack.Pop();
        double a = stack.Pop();
        double res = token switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => a / b,
            _ => throw new InvalidOperationException("Unknown operator")
        };
        stack.Push(res);
    }
}

double result = stack.Pop();