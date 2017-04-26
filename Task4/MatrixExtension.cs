using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Provides additional method for Matrix
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Calculates Sum of two matrices
        /// </summary>
        /// <typeparam name="T">Type of matrix elements</typeparam>
        /// <param name="matrix">First addend</param>
        /// <param name="other">Second addend</param>
        /// <returns>Sum of matrices</returns>
        public static Matrix<T> Sum<T>(this Matrix<T> matrix, Matrix<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException();
            var visitor = new Adder<T>(other);
            matrix.Accept(visitor);
            return visitor.Sum;
        }
    }
}
