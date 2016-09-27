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

        #region TestRandomData
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
        #endregion

        public sealed class Person
        {
            public string FirstName;
            public string LastName;
            public int Age;

            public override string ToString()
            {
                return
                    $"Name={this.FirstName} {this.LastName}, " +
                    $"Age={this.Age}";
            }
        }

        #region ExtractByFirstName
        public static Person[] ExtractByFirstName(Person[] persons, string firstName)
        {
            return persons.
                Where(person => person.FirstName == firstName).
                ToArray();
        }
        #endregion

        private static Person[] ExtractByFirstNameAndAge(
            Person[] persons, string firstName, int floorAge)
        {
            return persons.
                Where(person =>
                    (person.FirstName == firstName) &&
                    (person.Age >= floorAge)).
                ToArray();
        }

        private static void TestPerson()
        {
            var persons = new[]
            {
                new Person {FirstName = "Ichiro", LastName = "Yamada", Age = 22},
                new Person {FirstName = "Hanako", LastName = "Ehime", Age = 21},
                new Person {FirstName = "Ichiro", LastName = "Jouetsu", Age = 36},
                new Person {FirstName = "Shouta", LastName = "Tokuno", Age = 27},
                new Person {FirstName = "Ryouichi", LastName = "Nishiki", Age = 22},
                new Person {FirstName = "Kyoko", LastName = "Okashima", Age = 33},
                new Person {FirstName = "Hideto", LastName = "Ehime", Age = 24}
            };

            //var results = ExtractByFirstName(persons, "Ichiro");
            var results = ExtractByFirstNameAndAge(persons, "Ichiro", 25);
            Console.WriteLine(string.Join("\r\n", (object[])results));
        }

        static void Main(string[] args)
        {
            //TestRandomData();
            TestPerson();
        }
    }
}
