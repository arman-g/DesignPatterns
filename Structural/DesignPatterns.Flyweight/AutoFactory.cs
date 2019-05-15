using System;
using System.Collections.Generic;
using DesignPatterns.Flyweight.Abstractions;

namespace DesignPatterns.Flyweight
{
    public class AutoFactory
    {
        private static readonly Dictionary<string, IAuto> _autoList = new Dictionary<string, IAuto>();

        public IAuto GetAuto(Type autoType)
        {
            if (_autoList.ContainsKey(autoType.Name))
            {
                return _autoList[autoType.Name];
            }
            else
            {
                var auto = Activator.CreateInstance(autoType) as IAuto;
                _autoList.Add(auto.GetType().Name, auto);
                return auto;
            }
        }
    }
}
