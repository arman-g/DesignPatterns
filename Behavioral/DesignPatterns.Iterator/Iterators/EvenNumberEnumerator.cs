using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator.Iterators
{
    public class EvenNumberEnumerator : IEnumerator<int>
    {
        private int _currentIndex = -1;
        private readonly IList<int> _numbers;

        public int Current => _numbers[_currentIndex];
        object IEnumerator.Current => Current;

        public EvenNumberEnumerator(IList<int> numbers)
        {
            _numbers = numbers;
        }

        public bool MoveNext()
        {
            _currentIndex++;
            if (_currentIndex < _numbers.Count)
            {
                return _numbers[_currentIndex] % 2 == 0 || MoveNext();
            }
            else
            {
                return false;
            }
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
