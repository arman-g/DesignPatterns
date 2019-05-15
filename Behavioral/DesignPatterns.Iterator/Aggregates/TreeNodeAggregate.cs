using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DesignPatterns.CommonObjects.Enums;
using DesignPatterns.Iterator.Iterators;

namespace DesignPatterns.Iterator.Aggregates
{
    [Serializable]
    [DebuggerDisplay("Value = {" + nameof(Value) + "}")]
    public class TreeNode<T> : IEnumerable<T>
    {
        public T Value { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }
        public EnumeratorType EnumeratorType { get; set; } = EnumeratorType.DepthFirst;

        public TreeNode()
        {
        }

        public TreeNode(T value)
        {
            Value = value;
        }

        public TreeNode<T> Add(T value)
        {
            if (LeftChild == null)
            {
                LeftChild = new TreeNode<T>(value);
                return LeftChild;
            }
            else if (RightChild == null)
            {
                RightChild = new TreeNode<T>(value);
                return RightChild;
            }

            var ld = LeftChild.Depth();
            var rd = RightChild.Depth();
            if (LeftChild.Depth() <= RightChild.Depth())
            {
                return LeftChild.Add(value);
            }

            return RightChild.Add(value);
        }

        public int Depth()
        {
            if (LeftChild == null || RightChild == null) return 0;
            return 1 + Math.Min(LeftChild.Depth(), RightChild.Depth());
        }

        public IEnumerable<TreeNode<T>> Children()
        {
            if (LeftChild != null)
            {
                yield return LeftChild;
            }

            if (RightChild != null)
            {
                yield return RightChild;
            }
            yield break;
        }

        public IEnumerator<T> GetEnumerator()
        {
            switch (EnumeratorType)
            {
                case EnumeratorType.DepthFirst:
                    return new DepthFirstTreeEnumerator<T>(this);
                case EnumeratorType.BreadthFirst:
                    return new BreadthFirstTreeEnumerator<T>(this);
                default:
                    throw new NotImplementedException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
