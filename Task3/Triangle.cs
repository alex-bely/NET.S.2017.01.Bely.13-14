using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents Triangle figure
    /// </summary>
    public class Triangle:Figure
    {
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }

        /// <summary>
        /// Initializes Triangle instance
        /// </summary>
        /// <param name="firstSide">First side of triangle</param>
        /// <param name="secondSide">Second side of triangle</param>
        /// <param name="thirdSide">Third side of triangle</param>
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
           
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                throw new ArgumentOutOfRangeException("attempt of creating triangle with side <= 0");
            }

            
            if (firstSide + secondSide <= thirdSide
                || firstSide + thirdSide <= secondSide
                || secondSide + thirdSide <= firstSide)
            {
                throw new ArgumentOutOfRangeException("One of the side more than sum of two others");
            }

            
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

    }
}
