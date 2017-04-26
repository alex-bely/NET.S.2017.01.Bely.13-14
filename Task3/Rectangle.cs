using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents Rectangle figure
    /// </summary>
    public class Rectangle:Figure
    {
        public double Width { get; }
        public double Height { get; }

        /// <summary>
        /// Initializes Rectangle instance
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        /// <exception cref="ArgumentOutOfRangeException">attempt of creating a Rectangle with invalid side</exception>
        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("attempt of creating a Rectangle with side <= 0");
            }
            Width = width;
            Height = height;
        }
    }
}
