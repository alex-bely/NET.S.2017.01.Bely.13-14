using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Provides methods for handling with different types of matrix
    /// </summary>
    /// <typeparam name="T">Type of matrix elements</typeparam>
    public interface IMatrixVisitor<T>
    {
        SquareMatrix<T> Visit(SquareMatrix<T> matrix);
        SquareMatrix<T> Visit(SymmetricMatrix<T> matrix);
        SquareMatrix<T> Visit(DiagonalMatrix<T> matrix);
    }
}
