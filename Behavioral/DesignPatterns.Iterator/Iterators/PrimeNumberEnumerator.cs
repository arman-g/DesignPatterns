using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator.Iterators
{
    public class PrimeNumberEnumerator : IEnumerator<int>
    {
        private int _currentIndex = -1;
        private readonly IList<int> _numbers;

        public int Current => _numbers[_currentIndex];
        object IEnumerator.Current => Current;

        public PrimeNumberEnumerator(IList<int> numbers)
        {
            _numbers = numbers;
        }

        public bool MoveNext()
        {
            _currentIndex++;
            if (_currentIndex >= _numbers.Count) return false;
            var num = _numbers[_currentIndex];
            var k = 0;
            for (var i = 1; i <= num; i++)
            {
                if (num % i != 0) continue;
                k++;
                if (k > 2) break;
            }

            return k == 2 || MoveNext();
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public void Dispose()
        {
        }
    }
}
