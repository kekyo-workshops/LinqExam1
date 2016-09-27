using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExam1
{
    class Program
    {
        #region Infinite
        private static IEnumerable<int> Infinite(int value)
        {
            while (true)
            {
                yield return value;
            }
        }
        #endregion

        private static int[] CreateRandomData(int count)
        {
            return null;  // ...
        }

        private static void TestRandomData()
        {
            var data = CreateRandomData(100);
            Console.WriteLine(string.Join(",", data));
        }

        static void Main(string[] args)
        {
            TestRandomData();
        }
    }
}
