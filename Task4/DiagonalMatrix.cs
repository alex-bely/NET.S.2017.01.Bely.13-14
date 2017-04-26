using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Represent Diagonal matrix
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Indexer
        /// <summary>
        /// Indexer of the matrix
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
        /// <returns>Element with specified position</returns>
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

                if (i != j)
                    throw new ArgumentException();

                matrixArray[i, j] = value;
                OnValueChanged(new ValueChangedEventArgs(i, j));
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public DiagonalMatrix() : this(1) { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="order">Order of the matrix</param>
        public DiagonalMatrix(int order) : base(order)
        {
            for (int i = 0; i < Order; i++)
                for (int j = 0; j < Order; j++)
                    if (i != j) matrixArray[i, j].Equals(default(T));

        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="array">Source array</param>
        public DiagonalMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException();
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (i != j && !array[i, j].Equals(default(T)))
                        throw new ArgumentException();
                }
            }

            matrixArray = new T[array.GetLength(0), array.GetLength(0)];
            Order = array.GetLength(0);
            Array.Copy(array, matrixArray, array.Length);
        }
        #endregion

    }
}
