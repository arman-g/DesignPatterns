using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.NullObject.Abstractions;
using System;

namespace DesignPatterns.NullObject.Autos
{
    public class Bmw : AutomobileBase
    {
        public override Guid Id => new Guid("13225d7e-89f9-4f88-baca-30f3cb4ed3b6");
        public override string Name => "BMW i3";

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
