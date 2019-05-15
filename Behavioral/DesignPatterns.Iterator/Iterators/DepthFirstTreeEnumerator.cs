using DesignPatterns.Iterator.Aggregates;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator.Iterators
{
    public class DepthFirstTreeEnumerator<T> : IEnumerator<T>
    {
        private readonly TreeNode<T> _treeNode;
        private TreeNode<T> _current;
        private TreeNode<T> _previous;
        private readonly Stack<TreeNode<T>> _breadcrumb = new Stack<TreeNode<T>>();

        object IEnumerator.Current => Current;

        public T Current => _current.Value;

        public DepthFirstTreeEnumerator(TreeNode<T> treeNode)
        {
            _treeNode = treeNode;
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                Reset();
                _current = _treeNode;
                return true;
            }
            if (_current.LeftChild != null)
            {
                return TraverseLeft();
            }
            if (_current.RightChild != null)
            {
                return TraverseRight();
            }

            return TraverseUpAndRight();
        }

        public void Reset()
        {
            _current = null;
        }

        public void Dispose()
        {

        }

        private bool TraverseUpAndRight()
        {
            while (true)
            {
                if (_breadcrumb.Count == 0) return false;
                _previous = _current;
                _current = _breadcrumb.Pop();
                if (_current.RightChild != null && _previous != _current.RightChild) break;
            }

            if (_current.RightChild != null)
            {
                _breadcrumb.Push(_current);
                _current = _current.RightChild;
                return true;
            }

            return false;
        }

        private bool TraverseLeft()
        {
            _breadcrumb.Push(_current);
            _current = _current.LeftChild;
            return true;
        }

        private bool TraverseRight()
        {
            _breadcrumb.Push(_current);
            _current = _current.RightChild;
            return true;
        }
    }
}
