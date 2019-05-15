using DesignPatterns.SimpleFactory.Abstractions;
using DesignPatterns.SimpleFactory.ConcreteAutos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignPatterns.SimpleFactory.Factories
{
    public class AutoFactory
    {
        private IDictionary<string, Type> _autos;

        public AutoFactory()
        {
            LoadTypesICanReturn();
        }

        public IAuto CreateInstance(string carName)
        {
            var type = GetTypeToCreate(carName);
            if (type == null) return new NullAutomobile();

            return Activator.CreateInstance(type) as IAuto;
        }

        private Type GetTypeToCreate(string carName)
        {
            return _autos.FirstOrDefault(x => carName.Contains(x.Key, StringComparison.OrdinalIgnoreCase)).Value;
        }

        private void LoadTypesICanReturn()
        {
            _autos = new Dictionary<string, Type>();
            var typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in typesInThisAssembly)
            {
                if (typeof(IAuto).IsAssignableFrom(type))
                {
                    _autos.Add(type.Name.ToLower(), type);
                }
            }
        }
    }
}
