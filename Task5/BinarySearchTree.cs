using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// Represents Binary tree
    /// </summary>
    /// <typeparam name="T">Type of tree elements</typeparam>
    public class BinarySearchTree<T> : IEnumerable, IEnumerable<T>
    {
        /// <summary>
        /// Represents Node of tree
        /// </summary>
        private class Node
        {
            public T Value { get; set; }

            public Node Right { get; set; }

            public Node Left { get; set; }

            public Node(T value)
            {
                Value = value;
                Right = null;
                Left = null;
            }

            public Node() : this(default(T)) { }
        }

        #region Fields
        private Node root;
        private IComparer<T> comparer;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public BinarySearchTree():this(Comparer<T>.Default)
        { }

        /// <summary>
        /// Initializes Tree instance with specified comparer
        /// </summary>
        /// <param name="defaultComparer">Contains rule of comparing</param>
        public BinarySearchTree(IComparer<T> defaultComparer)
        {
            if (ReferenceEquals(defaultComparer, Comparer<T>.Default) && !((typeof(T).GetInterfaces().Contains(typeof(IComparable))) || (typeof(T).GetInterfaces().Contains(typeof(IComparable<T>)))))
                throw new TypeInitializationException("Type is not IComparable",new ArgumentException());

            if (ReferenceEquals(defaultComparer, null))
                comparer = Comparer<T>.Default;
            comparer = defaultComparer;
        }

        /// <summary>
        /// Initializes Tree instance with specified comparing rule
        /// </summary>
        /// <param name="defaultComparison">Contains rule of comparing</param>
        public BinarySearchTree(Comparison<T> defaultComparison) : this(Comparer<T>.Create(defaultComparison))
        {

        }

        /// <summary>
        /// Initializes Tree instance with elements of specified collection
        /// </summary>
        /// <param name="collection">Source collection</param>
        public BinarySearchTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default)
        {

        }

        /// <summary>
        /// Initializes Tree instance with elements of specified collection and specified comparer
        /// </summary>
        /// <param name="collection">Source collection</param>
        /// <param name="defaultComparer">>Contains rule of comparing</param>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> defaultComparer) : this(defaultComparer)
        {
            if ((ReferenceEquals(collection, null)))
                throw new ArgumentNullException();
            root = null;
            foreach (var item in collection)
                if (ReferenceEquals(root, null))
                    root = new Node(item);
                else this.Add(item);
        }

        /// <summary>
        /// Initializes Tree instance with elements of specified collection and specified comparing rule
        /// </summary>
        /// <param name="collection">Source collection</param>
        /// <param name="defaultComparer">>Contains rule of comparing</param>
        public BinarySearchTree(IEnumerable<T> collection, Comparison<T> defaultComparison) : this(collection, Comparer<T>.Create(defaultComparison))
        {

        }
        #endregion

        #region Public members
        /// <summary>
        /// Returns minimal element
        /// </summary>
        public T MinValue
        {
            get
            {
                if (ReferenceEquals(root, null))
                    throw new InvalidOperationException("Tree is empty");
                var current = root;
                while (current.Left != null)
                    current = current.Left;
                return current.Value;
            }
        }

        /// <summary>
        /// Returns maximal element
        /// </summary>
        public T MaxValue
        {
            get
            {
                if (ReferenceEquals(root, null))
                    throw new InvalidOperationException("Tree is empty");
                var current = root;
                while (current.Right != null)
                    current = current.Right;
                return current.Value;
            }
        }

        /// <summary>
        /// Insert value in the tree
        /// </summary>
        /// <param name="item">Inserted value</param>
        public void Add(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();

            if ((ReferenceEquals(root, null)))
                root = new Node(item);

            var currentNode = root;

            while (!ReferenceEquals(currentNode, null))
            {
                if (comparer.Compare(item, currentNode.Value) < 0)
                {
                    if (ReferenceEquals(currentNode.Left, null))
                    {
                        currentNode.Left = new Node(item);
                        break;
                    }
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (ReferenceEquals(currentNode.Right, null))
                    {
                        currentNode.Right = new Node(item);
                        break;
                    }
                    currentNode = currentNode.Right;
                }
            }
        }


        /// <summary>
        /// Removes value from the tree
        /// </summary>
        /// <param name="item">Removed value</param>
        public void Remove(T item)
        {

            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();

            if ((ReferenceEquals(root, null)))
                return;

            Node current = root;
            Node parent = null;

            while (!ReferenceEquals(current, null))
            {
                int comparingValue = comparer.Compare(item, current.Value);
                if (comparingValue == 0)
                    break;

                parent = current;
                current = comparingValue < 0 ? current.Left : current.Right;
            }

            if (ReferenceEquals(current, null))
                throw new ArgumentException();

            if (ReferenceEquals(current.Right, null))
            {
                if (ReferenceEquals(parent, null))
                    root = current.Left;
                else
                {
                    if (ReferenceEquals(current, parent.Left))
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Left;
                }
            }
            else if (ReferenceEquals(current.Left, null))
            {
                if (ReferenceEquals(parent, null))
                    root = current.Right;
                else
                {
                    if (ReferenceEquals(current, parent.Right))
                        parent.Right = current.Right;
                    else
                        parent.Left = current.Right;
                }
            }
            else
            {
                var tempNode = current.Right;
                parent = null;

                while (tempNode.Left != null)
                {
                    parent = tempNode;
                    tempNode = tempNode.Left;
                }

                if (parent != null)
                    parent.Left = tempNode.Right;
                else
                    current.Right = tempNode.Right;

                current.Value = tempNode.Value;
            }
        }

        /// <summary>
        /// Determines whether tree contains Node with specified item
        /// </summary>
        /// <param name="item">Searched item</param>
        /// <returns>True if contains, otherwise false</returns>
        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();

            var current = root;
            while (!ReferenceEquals(current, null))
            {
                var result = comparer.Compare(item, current.Value);
                if (result == 0)
                    return true;
                if (result < 0)
                    current = current.Left;
                else
                    current = current.Right;
            }
            return false;
        }

        /// <summary>
        /// Returns Node with specified item
        /// </summary>
        /// <param name="item">Searched item</param>
        /// <returns>Node with specified item</returns>
        public T Search(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();
            var current = root;

            while (!ReferenceEquals(current, null))
            {
                var result = comparer.Compare(item, current.Value);
                if (result == 0)
                    return current.Value;
                if (result < 0)
                    current = current.Left;
                else
                    current = current.Right;
            }

            return default(T);
        }

        /// <summary>
        /// Returns elements in pre-order Tree traversal
        /// </summary>
        /// <returns>Elements in pre-order Tree traversal</returns>
        public IEnumerable<T> PreOrder()
        {
            return PreOrder(root);
        }

        /// <summary>
        /// Returns elements in in-order Tree traversal
        /// </summary>
        /// <returns>Elements in in-order Tree traversal</returns>
        public IEnumerable<T> InOrder()
        {
            return InOrder(root);
        }

        /// <summary>
        /// Returns elements in post-order Tree traversal
        /// </summary>
        /// <returns>Elements in post-order Tree traversal</returns>
        public IEnumerable<T> PostOrder()
        {
            return PostOrder(root);
        }

        /// <summary>
        /// Returns enumerator instance with pre-order traversal
        /// </summary>
        /// <returns>Tree enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return PreOrder(root).GetEnumerator();
        }
        #endregion

        #region Private members
        
        /// <summary>
        /// Returns elements in pre-order Tree traversal
        /// </summary>
        /// <param name="node">Start of traversal</param>
        /// <returns>Elements in pre-order Tree traversal</returns>
        private IEnumerable<T> PreOrder(Node node)
        {
            if (ReferenceEquals(node, null))
                yield break;

            yield return node.Value;

            foreach (var item in PreOrder(node.Left))
                yield return item;

            foreach (var item in PreOrder(node.Right))
                yield return item;
        }

        /// <summary>
        /// Returns elements in in-order Tree traversal
        /// </summary>
        /// <param name="node">Start of traversal</param>
        /// <returns>Elements in in-order Tree traversal</returns>
        private IEnumerable<T> InOrder(Node node)
        {
            if (ReferenceEquals(node, null))
                yield break;

            foreach (var item in InOrder(node.Left))
                yield return item;

            yield return node.Value;

            foreach (var item in InOrder(node.Right))
                yield return item;
        }

        /// <summary>
        /// Returns elements in post-order Tree traversal
        /// </summary>
        /// <param name="node">Start of traversal</param>
        /// <returns>Elements in post-order Tree traversal</returns>
        private IEnumerable<T> PostOrder(Node node)
        {
            if (ReferenceEquals(node, null))
                yield break;

            foreach (var item in PostOrder(node.Left))
                yield return item;

            foreach (var item in PostOrder(node.Right))
                yield return item;

            yield return node.Value;
        }

        /// <summary>
        /// Returns Enumerator instance with pre-order traversal
        /// </summary>
        /// <returns>Enumerator instance with pre-order traversal</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
