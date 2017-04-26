using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Provides methods of matrix sum calculating
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public class Adder<T> : IMatrixVisitor<T>
    {
        private Matrix<T> temp;
        public Matrix<T> Sum { get; private set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="other">Another matrix for sum</param>
        public Adder(Matrix<T> other)
        {
            temp = other;
        }

        /// <summary>
        /// Calculates sum of given square matrix and another one 
        /// </summary>
        /// <param name="matrix">Addend of the sum</param>
        /// <returns>Sum of given square matrix and another one</returns>
        public SquareMatrix<T> Visit(SquareMatrix<T> matrix)
        {
            Sum = new SquareMatrix<T>(matrix.Order);
            for (int i = 0; i < matrix.Order; i++)
                for (int j = 0; j < matrix.Order; j++)
                    Sum[i, j] = (dynamic)matrix[i, j] + (dynamic)temp[i, j];
            return Sum as SquareMatrix<T>;
        }

        /// <summary>
        /// Calculates sum of given Symmetric matrix and another one 
        /// </summary>
        /// <param name="matrix">>Addend of the sum</param>
        /// <returns>Sum of given Symmetric matrix and another one </returns>
        public SquareMatrix<T> Visit(SymmetricMatrix<T> matrix)
        {
            Sum = new SquareMatrix<T>(matrix.Order);
            for (int i = 0; i < matrix.Order; i++)
                for (int j = 0; j < matrix.Order; j++)
                    Sum[i, j] = (dynamic)matrix[i, j] + (dynamic)temp[i, j];
            return Sum as SquareMatrix<T>;
        }

        /// <summary>
        /// Calculates sum of given Diagonal matrix and another one 
        /// </summary>
        /// <param name="matrix">Addend of the sum</param>
        /// <returns>Sum of given Diagonal matrix and another one </returns>
        public SquareMatrix<T> Visit(DiagonalMatrix<T> matrix)
        {
            Sum = new SquareMatrix<T>(matrix.Order);
            for (int i = 0; i < matrix.Order; i++)
                for (int j = 0; j < matrix.Order; j++)
                    Sum[i, j] = (dynamic)matrix[i, j] + (dynamic)temp[i, j];
            return Sum as SquareMatrix<T>;
        }
    }
}
