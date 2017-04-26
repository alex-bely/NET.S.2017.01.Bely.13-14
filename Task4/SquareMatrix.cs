using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Represents square matrix
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        public int Order { get; set; }
        #region Indexer
        /// <summary>
        /// Indexer of matrix
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Coumn index</param>
        /// <returns>Element of specified position</returns>
        public override T this[int i, int j]
        {
            get
            {
                return matrixArray[i, j];
            }
            set
            {
                if (i < 0 || j < 0 || i >= Order || j >= Order)
                    throw new IndexOutOfRangeException();

                matrixArray[i, j] = value;
                OnValueChanged(new ValueChangedEventArgs(i, j));

            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public SquareMatrix() : this(1) { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="order">Matrix order.</param>
        /// <exception cref="ArgumentException">Invalid order</exception>
        public SquareMatrix(int order)
        {
            if (order < 1)
                throw new ArgumentException("Invalid order");

            Order = order;
            matrixArray = new T[Order, Order];
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <exception cref="ArgumentNullException">Array is null referenced</exception>
        /// <exception cref="ArgumentException">Matrix is not square</exception>
        public SquareMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException("Array is null referenced");
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException("Matrix is not square");
            matrixArray = new T[array.GetLength(0), array.GetLength(0)];
            Order = array.GetLength(0);
            Array.Copy(array, matrixArray, array.Length);
        }
        #endregion

        /// <summary>
        /// Determines whether two square matrices are equal
        /// </summary>
        /// <param name="other">Matrix for comparing with current</param>
        /// <returns>True if matrices are equal, false otherwise</returns>
        public bool Equals(SquareMatrix<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (Order != other.Order)
                return false;

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (!Equals(this[i, j], other[i, j]))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether two matrices are equal
        /// </summary>
        /// <param name="other">Matrix for comparing with current</param>
        /// <returns>True if matrices are equal, false otherwise</returns>
        public override bool Equals(Matrix<T> other)
        {
            if (ReferenceEquals(other, null) || ReferenceEquals(other as SquareMatrix<T>, null))
                return false;
            if (ReferenceEquals(other as SquareMatrix<T>, this))
                return true;

            if (Order != (other as SquareMatrix<T>).Order)
                return false;

            return this.Equals(other as SquareMatrix<T>);
        }

        /// <summary>
        /// Subscribes to event
        /// </summary>
        public override void Register()
        {
            ValueChanged += delegate { matrixArray[0, 0] = (dynamic)matrixArray[0, 0] + 1; };
        }
    }
}
