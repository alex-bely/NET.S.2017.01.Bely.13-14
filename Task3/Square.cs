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
    public class Square : Rectangle
    {
        public double Side { get; }

        /// <summary>
        /// Initializes Square instance
        /// </summary>
        /// <param name="side">Side of square</param>
        public Square(double side):base(side,side)
        {
            Side = side;
        }
    }
}
