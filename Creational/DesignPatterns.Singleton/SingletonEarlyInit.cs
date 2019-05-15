namespace DesignPatterns.Singleton
{
    /// <summary>
    /// Represents Singleton design pattern with early initialization.
    /// </summary>
    /// <remarks>https://www.dofactory.com/net/singleton-design-pattern</remarks>
    public sealed class SingletonEarlyInit
    {
        private static readonly SingletonEarlyInit Instance = new SingletonEarlyInit();

        private SingletonEarlyInit() { }

        public static SingletonEarlyInit GetInstance()
        {
            return Instance;
        }
    }
}
