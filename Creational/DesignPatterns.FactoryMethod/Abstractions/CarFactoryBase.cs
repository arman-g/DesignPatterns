namespace DesignPatterns.FactoryMethod.Abstractions
{
    /// <summary>
    /// Base factory class. 
    /// </summary>
    /// <remarks>This can be and interface also but if factory
    /// will also support Null factory than abstract class might
    /// be a better solution.</remarks>
    public abstract class CarFactoryBase
    {
        public abstract CarBase Create(decimal miles = 0);
    }
}
