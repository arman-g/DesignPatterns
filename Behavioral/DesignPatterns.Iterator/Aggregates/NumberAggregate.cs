using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.Iterator.Iterators;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesignPatterns.Iterator.Aggregates
{
    public class NumberAggregate : ICollection<int>
    {
        private readonly ICollection<int> _collection = new Collection<int>();

        public int Count => _collection.Count;
        public bool IsReadOnly => false;
        public EnumeratorType EnumeratorType { get; set; }

        public NumberAggregate(){}

        public NumberAggregate(IEnumerable<int> list)
        {
            _collection = list.ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            switch (EnumeratorType)
            {
                case EnumeratorType.OddNumber:
                    return new OddNumberEnumerator(this.ToList());
                case EnumeratorType.EvenNumber:
                    return new EvenNumberEnumerator(this.ToList());
                case EnumeratorType.PrimeNumber:
                    return new PrimeNumberEnumerator(this.ToList());
                default:
                    return _collection.GetEnumerator();
            }
        }

        #region ' ICollection Implementation '

        public void Add(int item)
        {
            _collection.Add(item);
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(int item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(int item)
        {
            return _collection.Remove(item);
        }

        #endregion
    }
}