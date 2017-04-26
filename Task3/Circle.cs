using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents circle figure
    /// </summary>
    public class Circle:Figure
    {
        public double Radius { get; }

        /// <summary>
        /// Initializes Circle instance
        /// </summary>
        /// <param name="radius">Radius</param>
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException("attempt of creating a circle with radius <= 0");
            Radius = radius;
        }
    }
}
