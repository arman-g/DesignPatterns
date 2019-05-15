using DesignPatterns.Interpreter.Abstractions;

namespace DesignPatterns.Interpreter.DomainObjects
{
    public class Digit : IExpression
    {
        private readonly int _digit;

        public Digit(int digit)
        {
            _digit = digit;
        }

        public void Interpret(Context context)
        {
            context.Output += _digit.ToString();
        }
    }
}
