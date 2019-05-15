using DesignPatterns.Singleton;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatterns.xUnitTests
{
    public class SingletonTests
    {
        [Fact(DisplayName = "Lazy Initialization")]
        public void SingletonLazyInit_Test()
        {
            var obj1 = SingletonLazyInit.GetInstance();
            var obj2 = SingletonLazyInit.GetInstance();

            Assert.True(obj1 == obj2);
        }

        [Fact(DisplayName = "Lazy Initialization - Thread Safe")]
        public async Task SingletonLazyInit_ThreadSafe_Test()
        {
            var results = await Task.WhenAll(
                Task.Run(() => SingletonLazyInit.GetInstance()),
                Task.Run(() => SingletonLazyInit.GetInstance()),
                Task.Run(() => SingletonLazyInit.GetInstance()),
                Task.Run(() => SingletonLazyInit.GetInstance()),
                Task.Run(() => SingletonLazyInit.GetInstance()));

            var result = results.First();
            for (var i = 1; i < results.Length; i++)
            {
                Assert.Same(result, results[i]);
            }
        }

        [Fact(DisplayName = "Early Initialization")]
        public void SingletonEarlyInit_Test()
        {
            var obj1 = SingletonEarlyInit.GetInstance();
            var obj2 = SingletonEarlyInit.GetInstance();

            Assert.True(obj1 == obj2);
        }

        [Fact(DisplayName = "Early Initialization - Thread Safe")]
        public async Task SingletonEarlyInit_ThreadSafe_Test()
        {
            var results = await Task.WhenAll(
                Task.Run(() => SingletonEarlyInit.GetInstance()),
                Task.Run(() => SingletonEarlyInit.GetInstance()),
                Task.Run(() => SingletonEarlyInit.GetInstance()),
                Task.Run(() => SingletonEarlyInit.GetInstance()),
                Task.Run(() => SingletonEarlyInit.GetInstance()));

            var result = results.First();
            for (var i = 1; i < results.Length; i++)
            {
                Assert.Same(result, results[i]);
            }
        }
    }
}
