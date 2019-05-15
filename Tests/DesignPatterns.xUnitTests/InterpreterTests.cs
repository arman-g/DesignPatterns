using DesignPatterns.Interpreter.DomainObjects;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatterns.xUnitTests
{
    public class InterpreterTests
    {
        private readonly ITestOutputHelper _output;

        public InterpreterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Positive Case - Generate Bar Code")]
        public void BarCode_Test()
        {
            var upc = new Upc(
                new ManufacturerId(
                    new Digit(0),
                    new Digit(3),
                    new Digit(6),
                    new Digit(0),
                    new Digit(0),
                    new Digit(0)),
                new ItemNumber(
                    new Digit(2),
                    new Digit(9),
                    new Digit(1),
                    new Digit(4),
                    new Digit(5)),
                new CheckDigit()
                );

            var context = new Context();
            upc.Interpret(context: context);

            _output.WriteLine(context.Output);

            Assert.Equal(12, context.Output.Length);
            Assert.Equal('2', context.Output.Last(x => x == '2'));
        }
    }
}
