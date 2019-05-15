using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.NullObject.Autos;
using System;

namespace DesignPatterns.NullObject.Abstractions
{
    public abstract class AutomobileBase
    {
        public abstract Guid Id { get; }
        public abstract string Name { get; }
        public abstract CarStatus Start();
        public abstract CarStatus Stop();

        #region ' Null '

        private static readonly NullAutomobile NullAuto = new NullAutomobile();

        public static NullAutomobile Null => NullAuto;

        #endregion
    }
}
