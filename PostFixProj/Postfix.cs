using MyStackProj;
namespace PostFixProj;

public class Postfix
{
    public static int Evaluate(string expression)
    {
        var stack = new MyStack<int>();

        foreach (var token in expression.Split(' '))

        {
            if (int.TryParse(token, out int number))
            {
                stack.Push(number);
            }
            else
            {
                int y = stack.Pop();
                int x = stack.Pop();

                switch (token)
                {
                    case "+":
                        stack.Push(x + y);
                        break;
                    case "-":
                        stack.Push(x - y);
                        break;
                    case "*":
                        stack.Push(x * y);
                        break;
                    case "/":
                        stack.Push(x / y);
                        break;
                    
                }
            }
        }
        return stack.Pop();
    }
}
