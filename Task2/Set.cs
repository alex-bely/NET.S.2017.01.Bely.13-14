using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Represents disordered set of reference type element
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the set.</typeparam>
    public class Set<T> : IEnumerable<T> /*ISet<T>*/ where T : class, IEquatable<T>
    {
        #region Fields
        private IEqualityComparer<T> comparer;
        private T[] internalData;
        #endregion

        /// <summary>
        /// Returns amount of elements
        /// </summary>
        public int Count { get; private set; } = 0;
        #region Constructors
        /// <summary>
        /// Initializes instance of Set
        /// </summary>
        /// <param name="comparer">An equality comparer to compare elements.</param>
        public Set(IEqualityComparer<T> comparer = null)
        {
            if (ReferenceEquals(comparer, null))
                this.comparer = EqualityComparer<T>.Default;
            else this.comparer = comparer;
            internalData = new T[] { };
        }

        /// <summary>
        /// Initializes instance of Set
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new Set</param>
        /// <param name="comparer">An equality comparer to compare elements.</param>
        /// <exception cref="ArgumentNullException">Source collection is null referenced</exception>
        public Set(IEnumerable<T> collection, IEqualityComparer<T> comparer = null) : this(comparer)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException("Source collection is null referenced");
            this.internalData = new T[collection.Count()];
            foreach (var temp in collection)
                this.Add(temp);
        }
        #endregion


        #region Public members
        /// <summary>
        /// Determines whether a Set contains a specified element by using a specified IEqualityComparer<T>.
        /// </summary>
        /// <param name="item">A Set in which to locate an element.</param>
        /// <param name="comparer">An equality comparer to compare elements</param>
        /// <returns>True if the source Set contains an element that has the specified value; otherwise, false.</returns>
        public bool Contains(T item, IEqualityComparer<T> comparer = null)
        {
            if (ReferenceEquals(comparer, null))
                comparer = this.comparer;
            return internalData.Contains(item, comparer);
        }

        /// <summary>
        /// Adds an element to the end of the Set.
        /// </summary>
        /// <param name="item">Element to add</param>
        /// <exception cref="ArgumentNullException">Element is null referenced</exception>
        public void Add(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException("Item is null referenced");

            if (internalData.Contains(item, comparer))
            {
                return;
            }

            Array.Resize(ref internalData, Count+1);
            internalData[Count++]=item;
        }

        /// <summary>
        /// Removes an element from the Set
        /// </summary>
        /// <param name="item">Element to remove</param>
        /// <exception cref="ArgumentNullException">Element is null referenced</exception>
        public void Remove(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException("Item is null referenced");

            internalData = internalData.Where(x => !x.Equals(item)).ToArray();
            internalData = internalData.Where(x => !ReferenceEquals(x,null)).ToArray();
            Count = internalData.Length;
        }

        #region Static members
        /// <summary>
        /// Creates new Set instance that is a result of union of two sets
        /// </summary>
        /// <param name="first">First Set</param>
        /// <param name="second">Second Set</param>
        /// <returns>Set instance that is a result of union of two sets</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null referenced</exception>
        public static Set<T> Union(Set<T> first, Set<T> second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                throw new ArgumentNullException("One of arguments is null referenced");
            Set<T> result = new Set<T>(first);
            foreach (T item in second)
            {
                if (!first.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// Creates new Set instance that is a result of intersection of two sets
        /// </summary>
        /// <param name="first">First Set</param>
        /// <param name="second">Second Set</param>
        /// <returns>Set instance that is a result of intersection of two sets</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null referenced</exception>
        public static Set<T> Intersection(Set<T> first, Set<T> second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                throw new ArgumentNullException();
            Set<T> result = new Set<T>();
            foreach (T item in first)
            {
                if (second.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }


        /// <summary>
        /// Creates new Set instance that is a result of difference of two sets
        /// </summary>
        /// <param name="first">First Set</param>
        /// <param name="second">Second Set</param>
        /// <returns>Set instance that is a result of difference of two sets</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null referenced</exception>
        public static Set<T> Difference(Set<T> first, Set<T> second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                throw new ArgumentNullException();

            Set<T> result = new Set<T>(first);
            foreach (T item in second)
            {
                result.Remove(item);
            }
            return result;
        }

        /// <summary>
        /// Creates new Set instance that is a result of symmetric difference of two sets
        /// </summary>
        /// <param name="first">First Set</param>
        /// <param name="second">Second Set</param>
        /// <returns>Set instance that is a result of symmetric difference of two sets</returns>
        /// <exception cref="ArgumentNullException">One of arguments is null referenced</exception>
        public static Set<T> SymmetricDifference(Set<T> first, Set<T> second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                throw new ArgumentNullException();

            return Difference(Union(first, second), Intersection(first, second));
        }
        #endregion

        /// <summary>
        /// Creates new Set instance that is a result of union of two sets
        /// </summary>
        /// <param name="other">Another set</param>
        /// <returns>Set instance that is a result of union of two sets</returns>
        /// <exception cref="ArgumentNullException">Argument is null referenced</exception>
        public Set<T> UnionWith(Set<T> other)
        {
            if (ReferenceEquals(other, null) || ReferenceEquals(other, null))
                throw new ArgumentNullException();
            return Union(this, other);
        }

        /// <summary>
        /// Creates new Set instance that is a result of intersection of two sets
        /// </summary>
        /// <param name="other">Another set</param>
        /// <returns>Set instance that is a result of intersection of two sets</returns>
        /// <exception cref="ArgumentNullException">Argument is null referenced</exception>
        public Set<T> IntersectionWith(Set<T> other)
        {
            if (ReferenceEquals(other, null) || ReferenceEquals(other, null))
                throw new ArgumentNullException();
            return Intersection(this, other);
        }


        /// <summary>
        /// Creates new Set instance that is a result of difference of two sets
        /// </summary>
        /// <param name="other">Another set</param>
        /// <returns>Set instance that is a result of difference of two sets</returns>
        /// <exception cref="ArgumentNullException">Argument is null referenced</exception>
        public Set<T> DifferenceWith(Set<T> other)
        {
            if (ReferenceEquals(other, null) || ReferenceEquals(other, null))
                throw new ArgumentNullException();
            return Difference(this, other);
        }

        /// <summary>
        /// Creates new Set instance that is a result of symmetric difference of two sets
        /// </summary>
        /// <param name="other">Another set</param>
        /// <returns>Set instance that is a result of symmetric difference of two sets</returns>
        /// <exception cref="ArgumentNullException">Argument is null referenced</exception>
        public Set<T> SymmetricDifferenceWith(Set<T> other)
        {
            if (ReferenceEquals(other, null) || ReferenceEquals(other, null))
                throw new ArgumentNullException();
            return SymmetricDifference(this, other);
        }


        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            Set<T> setObj = obj as Set<T>;
            if (ReferenceEquals(obj, null))
                return false;
            else
                return Equals(setObj);
        }

        /// <summary>
        /// Returns value of hash-code
        /// </summary>
        /// <returns>Integer value of hash-code</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var temp in internalData)
            {
                hash += temp.GetHashCode();
            }
            return hash;

        }

        /// <summary>
        /// Determines whether the specified Set is equal to the current one.
        /// </summary>
        /// <param name="anotherSet">The Set to compare with the current one.</param>
        /// <returns>true if the specified Set is equal to the current one; otherwise, false.</returns>
        public bool Equals(Set<T> anotherSet)
        {
            if (ReferenceEquals(anotherSet, null))
                return false;
            if (ReferenceEquals(anotherSet, this))
                return true;

            if (this.Count != anotherSet.Count) return false;
            foreach (var temp in anotherSet)
                if (!this.Contains(temp)) return false;
            return true;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the Set.
        /// </summary>
        /// <returns>An enumerator that iterates through the Set</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var temp in internalData)
                yield return temp;
        }
        #endregion

        #region Private member
        /// <summary>
        ///  Returns an enumerator that iterates through the Set.
        /// </summary>
        /// <returns>An enumerator that iterates through the Set.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        } 
        #endregion
    }
}
