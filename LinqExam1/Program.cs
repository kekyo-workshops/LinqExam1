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

        #region CreateRandomData
        private static int[] CreateRandomData(int count)
        {
            var r = new Random();
            var data = new int[count];
            for (var index = 0; index < data.Length; index++)
            {
                data[index] = r.Next();
            }
            return data;
        }

        private static int[] CreateRandomDataForLINQ(int count)
        {
            var r = new Random();
            return
                Infinite(0).
                Select(value => r.Next()).
                Take(count).
                ToArray();
        }
        #endregion

        private static void TestRandomData()
        {
            //var data = CreateRandomData(100);
            var data = CreateRandomDataForLINQ(100);
            Console.WriteLine(string.Join(",", data));
        }

        static void Main(string[] args)
        {
            TestRandomData();
        }
    }
}
