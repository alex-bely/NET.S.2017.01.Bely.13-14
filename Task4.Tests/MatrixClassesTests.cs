using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;

namespace Task4.Tests
{
    public class MatrixClassesTests
    {
        #region Source matrix
        public static readonly Matrix<int> SquareMatrix =
            new SquareMatrix<int>(new[,]
                {
                    {1, 2, 3 },
                    {4, 5, 6 },
                    {7, 8, 9 }
                });


        public static readonly Matrix<int> SymmetricMatrix =
            new SymmetricMatrix<int>(new[,]
                {
                    {1, 4, 7 },
                    {4, 5, 8 },
                    {7, 8, 9 }
                });

        public static readonly Matrix<int> DiagonalMatrix =
            new DiagonalMatrix<int>(new[,]
                {
                    {10, 0, 0 },
                    {0, 10, 0 },
                    {0, 0, 10 }
                });
        #endregion


        #region Expected matrix

        public static readonly SquareMatrix<int> SquarePlusSquareMatrix =
            new SquareMatrix<int>(new[,]
                {
                    {2, 4, 6 },
                    {8, 10, 12 },
                    {14, 16, 18 }
                });

        public static readonly SquareMatrix<int> SymmetricPlusSquareMatrix =
            new SquareMatrix<int>(new[,]
                {
                    {2, 6, 10 },
                    {8, 10, 14 },
                    {14, 16, 18 }
                });

        public static readonly SquareMatrix<int> DiagonalPlusSquareMatrix =
            new SquareMatrix<int>( new[,]
                {
                    {11, 2, 3 },
                    {4, 15, 6 },
                    {7, 8, 19 }
                });

        public static readonly SquareMatrix<int> SymmetricPlusDiagonalMatrix =
            new SquareMatrix<int>( new[,]
                {
                    {11, 4, 7 },
                    {4, 15, 8 },
                    {7, 8, 19 }
                });


        public static readonly SquareMatrix<int> DiagonalPlusDiagonalMatrix =
            new SquareMatrix<int>(new[,]
                {
                    {20, 0, 0 },
                    {0, 20, 0 },
                    {0, 0, 20 }
                });
        #endregion

        #region Test cases
        [TestCase(ExpectedResult =true)]
        public bool Sum_SquareMatrixPlusSquareMatrix()
        {
            return (SquareMatrix.Sum(SquareMatrix)).Equals(SquarePlusSquareMatrix);
        }

        [TestCase(ExpectedResult = true)]
        public bool Sum_DiagonalMatrixPlusSquareMatrix()
        {
            return (DiagonalMatrix.Sum(SquareMatrix)).Equals(DiagonalPlusSquareMatrix);
        }

        [TestCase(ExpectedResult = true)]
        public bool Sum_SymmetricMatrixPlusSquareMatrix()
        {
            return (SymmetricMatrix.Sum(SquareMatrix)).Equals(SymmetricPlusSquareMatrix);
        }

        [TestCase(ExpectedResult = true)]
        public bool Sum_SymmetricMatrixPlusDiagonalMatrix()
        {
            return (SymmetricMatrix.Sum(DiagonalMatrix)).Equals(SymmetricPlusDiagonalMatrix);
        }

        [TestCase(ExpectedResult = true)]
        public bool Sum_DiagonalMatrixPlusDiagonalMatrix()
        {
            return (DiagonalMatrix.Sum(DiagonalMatrix)).Equals(DiagonalPlusDiagonalMatrix);
        }

        #endregion
    }
}
