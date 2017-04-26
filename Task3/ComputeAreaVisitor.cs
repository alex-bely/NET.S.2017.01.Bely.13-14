using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Calculates area of determined type of figure
    /// </summary>
    public class ComputeAreaVisitor: IFigureVisitor
    {
        public double Area { get; private set; }

        /// <summary>
        /// Calculates area of circle
        /// </summary>
        /// <param name="circle">Circle instance</param>
        public void Visit(Circle circle)
        {
            Area = Math.PI * Math.Pow(circle.Radius,2);
        }
        /// <summary>
        /// Calculates area of square
        /// </summary>
        /// <param name="square">Square instance</param>
        public void Visit(Square square)
        {
            Area = Math.Pow(square.Side,2);
        }
        /// <summary>
        /// Calculates area of Rectangle
        /// </summary>
        /// <param name="Rectangle">Rectangle instance</param>
        public void Visit(Rectangle Rectangle)
        {
            Area = Rectangle.Width * Rectangle.Height;
        }
        /// <summary>
        /// Calculates area of triangle
        /// </summary>
        /// <param name="triangle">Triangle instance</param>
        public void Visit(Triangle triangle)
        {
            double semiperimeter = (triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide) / 2;
            Area = Math.Sqrt(semiperimeter * (semiperimeter - triangle.FirstSide) * (semiperimeter - triangle.SecondSide) * (semiperimeter - triangle.ThirdSide));
        }
    }
}
