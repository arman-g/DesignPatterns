using DesignPatterns.Interpreter.DomainObjects;

namespace DesignPatterns.Interpreter.Abstractions
{
    public interface IExpression
    {
        void Interpret(Context context);
    }
}
