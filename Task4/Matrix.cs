using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Represents Matrix object
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public abstract class Matrix<T> : IEnumerable<T>, IEnumerable, IEquatable<Matrix<T>>
    {
        protected T[,] matrixArray;

        #region Abstract methods
        /// <summary>
        /// Determines whether two matrix are equal
        /// </summary>
        /// <param name="other">Matrix for comparing</param>
        /// <returns>True if matrices are equal, false otherwise</returns>
        public abstract bool Equals(Matrix<T> other);
        /// <summary>
        /// Matrix indexer
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
        /// <returns>Element with specified position</returns>
        public abstract T this[int i, int j] { get; set; }
        /// <summary>
        /// Subcribes to event
        /// </summary>
        public abstract void Register();
        #endregion

        #region Event
        /// <summary>
        /// EventHandler
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> ValueChanged = delegate { };
        /// <summary>
        /// Performs subscribers events
        /// </summary>
        /// <param name="e">Object with additional information</param>
        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            EventHandler<ValueChangedEventArgs> temp = ValueChanged;
            temp?.Invoke(this, e);
        }
        #endregion

        #region Implemented methods
        /// <summary>
        /// Invokes visitor's method
        /// </summary>
        /// <param name="visitor">Given visitor</param>
        public void Accept(IMatrixVisitor<T> visitor)
        {
            visitor.Visit((dynamic)this);
        }

        /// <summary>
        /// Returns matrix enumerator
        /// </summary>
        /// <returns>Matrix enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in matrixArray)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

    }
}
