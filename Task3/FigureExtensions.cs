using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Provides extension methods for calculateing are and perimeter of figures
    /// </summary>
    public static class FigureExtensions
    {
        /// <summary>
        /// Calculates figure area
        /// </summary>
        /// <param name="shape">Figure instance</param>
        /// <returns>Figure area</returns>
        public static double GetArea(this Figure shape)
        {
            var visitor = new ComputeAreaVisitor();
            shape.Accept(visitor);
            return visitor.Area;
        }

        /// <summary>
        /// Calculates figure perimeter
        /// </summary>
        /// <param name="shape">Figure instance</param>
        /// <returns>Figure perimeter</returns>
        public static double GetPerimeter(this Figure shape)
        {
            var visitor = new ComputePerimeterVisitor();
            shape.Accept(visitor);
            return visitor.Perimeter;
        }
    }
}
