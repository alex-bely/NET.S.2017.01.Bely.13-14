using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

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
        public static IEnumerable<BigInteger> CreateNewSequance(int count)
        {
            if(count<0)
                throw new ArgumentOutOfRangeException("Negative amount of numbers!");
            return CreateNewSequanceCore(count);
        }


        /// <summary>
        /// Creates enumerable Fibonacchi sequance
        /// </summary>
        /// <param name="count">Amount of elements</param>
        /// <returns>Enumerable Fibonacchi sequance</returns>
        private static IEnumerable<BigInteger> CreateNewSequanceCore(int count)
        {
            int i = 0;
            long penultimate = 1;
            long last = 0;
            long temp = 0;
            while (i < count)
            {
                yield return temp;
                try
                {
                    temp = checked(penultimate + last);
                }
                catch { yield break; } 
                penultimate = last;
                last = temp;
                i++;
            }
        }
    }
}
