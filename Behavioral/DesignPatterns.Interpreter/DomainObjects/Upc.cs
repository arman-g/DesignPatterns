using DesignPatterns.Interpreter.Abstractions;

namespace DesignPatterns.Interpreter.DomainObjects
{
    public class Upc : IExpression
    {
        private readonly ManufacturerId _manufacturerId;
        private readonly ItemNumber _itemNumber;
        private readonly CheckDigit _checkDigit;

        public Upc(ManufacturerId manufacturerId, ItemNumber itemNumber, CheckDigit checkDigit)
        {
            _manufacturerId = manufacturerId;
            _itemNumber = itemNumber;
            _checkDigit = checkDigit;
        }

        public void Interpret(Context context)
        {
            _manufacturerId.Interpret(context);
            _itemNumber.Interpret(context);
            _checkDigit.Interpret(context);
        }
    }
}
