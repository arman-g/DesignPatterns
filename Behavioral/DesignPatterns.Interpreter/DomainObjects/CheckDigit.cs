using DesignPatterns.Interpreter.Abstractions;
using System;

namespace DesignPatterns.Interpreter.DomainObjects
{
    public class CheckDigit : IExpression
    {
        public void Interpret(Context context)
        {
            var upperBound = context.Output.Length - 1;
            int evenTotal = 0, oddTotal = 0, checkDigit = 0;

            for (var i = 0; i <= upperBound; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    evenTotal += Convert.ToInt32(context.Output[i].ToString());
                }
                else
                {
                    oddTotal += Convert.ToInt32(context.Output[i].ToString());
                }
            }

            var reminder = (evenTotal + 3 * oddTotal) % 10;
            if (reminder > 0)
            {
                checkDigit = 10 - reminder;
            }

            context.Output += checkDigit.ToString();
        }
    }
}
