namespace DesignPatterns.Singleton
{
    /// <summary>
    /// Represents Singleton design pattern with lazy initialization.
    /// </summary>
    /// <remarks>https://www.dofactory.com/net/singleton-design-pattern</remarks>
    public class SingletonLazyInit
    {
        private static volatile SingletonLazyInit _instance;

        private static readonly object SyncLock = new object();

        protected SingletonLazyInit() { }

        public static SingletonLazyInit GetInstance()
        {
            if (_instance != null) return _instance;
            lock (SyncLock)
            {
                if (_instance == null)
                {
                    _instance = new SingletonLazyInit();
                }
            }

            return _instance;
        }
    }
}
