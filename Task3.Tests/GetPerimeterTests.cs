using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3.Tests
{
    class GetPerimeterTests
    {
        [TestCase(4, ExpectedResult = Math.PI * 8)]
        [TestCase(5, ExpectedResult = Math.PI * 10)]
        [TestCase(6, ExpectedResult = Math.PI * 12)]
        [TestCase(7, ExpectedResult = Math.PI * 14)]
        public double GetPerimeter_Circle(double radius) => (new Circle(radius)).GetPerimeter();

        [TestCase(10, ExpectedResult = 40)]
        [TestCase(20, ExpectedResult = 80)]
        [TestCase(30, ExpectedResult = 120)]
        [TestCase(40, ExpectedResult = 160)]
        public double GetPerimeter_Square(double side) => (new Square(side)).GetPerimeter();

        [TestCase(5, 6, ExpectedResult = 22)]
        [TestCase(1, 3, ExpectedResult = 8)]
        [TestCase(3, 10, ExpectedResult = 26)]
        [TestCase(10, 20, ExpectedResult = 60)]
        [TestCase(30, 20, ExpectedResult = 100)]
        public double GetPerimeter_Rectangle(double width, double height) => (new Rectangle(width, height)).GetPerimeter();

        [TestCase(1, 1, 1, ExpectedResult = 3)]
        [TestCase(8, 9, 9, ExpectedResult = 26)]
        [TestCase(3, 4, 5, ExpectedResult = 12)]
        public double GetPerimeter_Triangle(double a, double b, double c) => (new Triangle(a, b, c)).GetPerimeter();
    }
}
