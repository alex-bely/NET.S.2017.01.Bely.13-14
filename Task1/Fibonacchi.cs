using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Provides method to create Fibonacci sequance
    /// </summary>
    public class Fibonacchi
    {
        /// <summary>
        /// Creates enumerable Fibonacchi sequance
        /// </summary>
        /// <param name="count">Amount of elements</param>
        /// <returns>Enumerable Fibonacchi sequance</returns>
        /// <exception cref="ArgumentOutOfRangeException">Negative amount of numbers</exception>
        /// <exception cref="OverflowException">Fibonacchi number is too big</exception>
        public static IEnumerable<long> CreateNewSequance(int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException("Negative amount of numbers!");

            int i = 0;
            long penultimate = 1;
            long last = 0;
            long temp = 0;
            checked
            {
                while (i < count)
                {
                    yield return temp;
                    temp = penultimate + last;
                    penultimate = last;
                    last = temp;
                    i++;
                }
            }
        }
    }
}
