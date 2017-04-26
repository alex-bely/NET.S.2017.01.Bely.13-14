using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Represents Symmetric matrix
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="i">Row index</param>
        /// <param name="j">Column index</param>
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
                matrixArray[j, i] = value;
                OnValueChanged(new ValueChangedEventArgs(i, j));

            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SymmetricMatrix() : this(1) { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="order">Matrix order</param>
        public SymmetricMatrix(int order) : base(order) { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="array">Source array</param>
        /// <exception cref="ArgumentNullException">Array is null referenced</exception>
        /// <exception cref="ArgumentException">"Matrix is not square"</exception>
        public SymmetricMatrix(T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException("Array is null referenced");
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException("Matrix is not square");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (!Equals(array[i, j], array[j, i]))
                        throw new ArgumentException();
                }
            }

            matrixArray = new T[array.GetLength(0), array.GetLength(0)];
            Order = array.GetLength(0);
            Array.Copy(array, matrixArray, array.Length);
        }

        /// <summary>
        /// Subscribes to event
        /// </summary>
        public override void Register()
        {
            ValueChanged += delegate { matrixArray[Order - 1, Order - 1] = (dynamic)matrixArray[Order - 1, Order - 1] * 2; };
        }

    }
}
