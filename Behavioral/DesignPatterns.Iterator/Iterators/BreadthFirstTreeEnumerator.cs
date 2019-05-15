using DesignPatterns.Iterator.Aggregates;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator.Iterators
{
    public class BreadthFirstTreeEnumerator<T> : IEnumerator<T>
    {
        private readonly TreeNode<T> _treeNode;
        private TreeNode<T> _current;
        private readonly Queue<IEnumerator<TreeNode<T>>> _enumerators = new Queue<IEnumerator<TreeNode<T>>>();

        object IEnumerator.Current => Current;

        public T Current => _current.Value;

        public BreadthFirstTreeEnumerator(TreeNode<T> treeNode)
        {
            _treeNode = treeNode;
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                Reset();
                _current = _treeNode;
                _enumerators.Enqueue(_current.Children().GetEnumerator());
                return true;
            }

            while (_enumerators.Count > 0)
            {
                var enumerator = _enumerators.Peek();
                if (enumerator.MoveNext())
                {
                    _current = enumerator.Current;
                    _enumerators.Enqueue(_current.Children().GetEnumerator());
                    return true;
                }
                else
                {
                    _enumerators.Dequeue();
                }
            }

            return false;
        }

        public void Reset()
        {
            _current = null;
        }

        public void Dispose()
        {

        }
    }
}
