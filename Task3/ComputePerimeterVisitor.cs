using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    ///  Calculates perimeter of determined type of figure
    /// </summary>
    public class ComputePerimeterVisitor:IFigureVisitor
    {
        public double Perimeter { get; private set; }

        /// <summary>
        /// Calculates perimeter of circle
        /// </summary>
        /// <param name="circle">Circle instance</param>
        public void Visit(Circle circle)
        {
            Perimeter = 2 * Math.PI * circle.Radius;
        }

        /// <summary>
        /// Calculates perimeter of square
        /// </summary>
        /// <param name="square">Square instance</param>
        public void Visit(Square square)
        {
            Perimeter = 4 * square.Side;
        }

        /// <summary>
        /// Calculates perimeter of Rectangle
        /// </summary>
        /// <param name="Rectangle">Rectangle instance</param>
        public void Visit(Rectangle Rectangle)
        {
            Perimeter = 2 * (Rectangle.Width + Rectangle.Height);
        }

        /// <summary>
        /// Calculates perimeter of triangle
        /// </summary>
        /// <param name="triangle">Triangle instance</param>
        public void Visit(Triangle triangle)
        {
             Perimeter = triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide;
        }
    }
}
