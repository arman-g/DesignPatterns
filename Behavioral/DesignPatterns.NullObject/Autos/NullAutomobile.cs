using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.NullObject.Abstractions;
using System;

namespace DesignPatterns.NullObject.Autos
{
    public class NullAutomobile : AutomobileBase
    {
        public override Guid Id => Guid.Empty;
        public override string Name => string.Empty;

        public override CarStatus Start()
        {
            return CarStatus.None;
        }

        public override CarStatus Stop()
        {
            return CarStatus.None;
        }
    }
}
