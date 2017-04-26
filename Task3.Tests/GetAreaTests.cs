using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3.Tests
{
    class GetAreaTests
    {
        [TestCase(4, ExpectedResult = Math.PI * 16)]
        [TestCase(5, ExpectedResult = Math.PI * 25)]
        [TestCase(6, ExpectedResult = Math.PI * 36)]
        public double GetArea_Circle(double radius) => (new Circle(radius)).GetArea();

        [TestCase(10, ExpectedResult = 100)]
        [TestCase(20, ExpectedResult = 400)]
        [TestCase(30, ExpectedResult = 900)]
        public double GetArea_Square(double side) => (new Square(side)).GetArea();

        [TestCase(5, 2, ExpectedResult = 10)]
        [TestCase(3, 5, ExpectedResult = 15)]
        [TestCase(2, 6, ExpectedResult = 12)]
        public double GetArea_Rectangle(double width, double height) => (new Rectangle(width, height)).GetArea();

        [TestCase(3, 4, 5, ExpectedResult = 6)]
        public double GetArea_Triangle(double a, double b, double c) => (new Triangle(a, b, c)).GetArea();
    }
}
