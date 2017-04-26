using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class FibonacchiTests
    {

        [TestCase(1)]
        public void CreateNewSequance_Number1(int count)
        {
            Assert.AreEqual(Fibonacchi.CreateNewSequance(count).ToArray(), new long[]{0});
        }
        [TestCase(2)]
        public void CreateNewSequance_Number2(int count)
        {
            Assert.AreEqual(Fibonacchi.CreateNewSequance(count).ToArray(), new long[] { 0,1 });
        }
        [TestCase(3)]
        public void CreateNewSequance_Number3(int count)
        {
            Assert.AreEqual(Fibonacchi.CreateNewSequance(count).ToArray(), new long[] { 0,1,1 });
        }
        [TestCase(4)]
        public void CreateNewSequance_Number4(int count)
        {
            Assert.AreEqual(Fibonacchi.CreateNewSequance(count).ToArray(), new long[] { 0,1,1,2 });
        }
        [TestCase(5)]
        public void CreateNewSequance_Number5(int count)
        {
            Assert.AreEqual(Fibonacchi.CreateNewSequance(count).ToArray(), new long[] { 0, 1, 1, 2,3 });
        }
        

    }
}
