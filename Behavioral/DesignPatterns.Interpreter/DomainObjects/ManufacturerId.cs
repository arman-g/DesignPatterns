using DesignPatterns.Interpreter.Abstractions;

namespace DesignPatterns.Interpreter.DomainObjects
{
    public class ManufacturerId : IExpression
    {
        private readonly Digit _digit1;
        private readonly Digit _digit2;
        private readonly Digit _digit3;
        private readonly Digit _digit4;
        private readonly Digit _digit5;
        private readonly Digit _digit6;


        public ManufacturerId(Digit digit1, Digit digit2, Digit digit3, Digit digit4, Digit digit5, Digit digit6)
        {
            _digit1 = digit1;
            _digit2 = digit2;
            _digit3 = digit3;
            _digit4 = digit4;
            _digit5 = digit5;
            _digit6 = digit6;
        }
        public void Interpret(Context context)
        {
            _digit1.Interpret(context);
            _digit2.Interpret(context);
            _digit3.Interpret(context);
            _digit4.Interpret(context);
            _digit5.Interpret(context);
            _digit6.Interpret(context);
        }
    }
}
