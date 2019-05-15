using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.NullObject.Abstractions;
using System;

namespace DesignPatterns.NullObject.Autos
{
    public class Audi : AutomobileBase
    {
        public override Guid Id => new Guid("8808a06e-0103-4963-8895-0e2cb55024c1");
        public override string Name => "Audi A5";

        public override CarStatus Start()
        {
            return CarStatus.On;
        }

        public override CarStatus Stop()
        {
            return CarStatus.Off;
        }
    }
}
