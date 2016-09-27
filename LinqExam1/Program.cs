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

        #region CreateRandomEvenData
        private static int[] CreateRandomEvenData(int count)
        {
            var r = new Random();
            var data = new int[count];
            var index = 0;
            while (index < count)
            {
                var value = r.Next();
                if ((value % 2) == 0)
                {
                    data[index] = value;
                    index++;
                }
            }
            return data;
        }

        private static int[] CreateRandomEvenDataForLINQ(int count)
        {
            var r = new Random();
            return
                Infinite(0).
                Select(value => r.Next()).
                Where(value => (value % 2) == 0).
                Take(count).
                ToArray();
        }
        #endregion

        #region CreateRandomEvenDistinctData
        private static int[] CreateRandomEvenDistinctData(int count)
        {
            var r = new Random();
            var data = new int[count];
            var index = 0;
            while (index < count)
            {
                var value = r.Next();
                if ((value % 2) == 0)
                {
                    var found = false;
                    for (var innerIndex = 0; innerIndex < index; innerIndex++)
                    {
                        if (value == data[innerIndex])
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        data[index] = value;
                        index++;
                    }
                }
            }
            return data;
        }

        private static int[] CreateRandomEvenDistinctDataForLINQ(int count)
        {
            var r = new Random();
            return
                Infinite(0).
                Select(index => r.Next()).
                Where(value => (value % 2) == 0).
                Distinct().
                Take(count).
                ToArray();
        }
        #endregion

        private static void TestRandomData()
        {
            //var data = CreateRandomData(100);
            //var data = CreateRandomDataForLINQ(100);
            //var data = CreateRandomEvenData(100);
            //var data = CreateRandomEvenDataForLINQ(100);
            //var data = CreateRandomEvenDistinctData(100);
            var data = CreateRandomEvenDistinctDataForLINQ(100);
            Console.WriteLine(string.Join(",", data));
        }

        static void Main(string[] args)
        {
            TestRandomData();
        }
    }
}
