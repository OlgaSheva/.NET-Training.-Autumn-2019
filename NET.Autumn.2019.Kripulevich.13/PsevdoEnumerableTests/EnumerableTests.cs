using NUnit.Framework;
using PsevdoEnumerable;
using System.Collections;
using System.Collections.Generic;

namespace PsevdoEnumerableTests
{
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class EnumerableTests
    {
        Pet[] pets = { new Pet { Name="Barley", Age=10 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=6 } };

        string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

        [Test]
        public void ForAll_NameStartWithB()
        {
            Assert.IsFalse(pets.ForAll(pet => pet.Name.StartsWith("B")));
        }

        [Test]
        public void Count_PetsName()
        {
            Assert.AreEqual(pets.Count(p => p.Name == "Barley"), 1);
        }

        [Test]
        public void Count_Fruits()
        {
            Assert.AreEqual(fruits.Count(), 6);
        }

        [Test]
        public void SortBy_PetsAge()
        {
            IEnumerable<Pet> query = pets.SortBy(pet => pet.Age);
            Pet[] actual = System.Linq.Enumerable.ToArray(query);
            Pet[] sortedPets = { new Pet { Name="Boots", Age=4 },
                                 new Pet { Name="Whiskers", Age=6 },
                                 new Pet { Name="Barley", Age=10 }};
            Assert.AreEqual(sortedPets[0].Age, actual[0].Age);
            Assert.AreEqual(sortedPets[1].Age, actual[1].Age);
            Assert.AreEqual(sortedPets[2].Age, actual[2].Age);
        }

        [Test]
        public void SortBy_FruitsByLength()
        {
            IEnumerable<string> query = fruits.SortBy(fruit => fruit.Length);
            string[] expected = { "apple", "mango", "grape", "orange", "banana", "passionfruit" };
            Assert.AreEqual(query, expected);
        }

        [Test]
        public void CastTo()
        {
            ArrayList fruits = new ArrayList
            {
                "mango",
                "apple",
                "lemon"
            };
            ArrayList expected = new ArrayList
            {
                "apple",
                "lemon",
                "mango"
            };

            IEnumerable<string> query =
                Enumerable.CastTo<string>(fruits).SortBy(fruit => fruit);
            Assert.AreEqual(expected, query);
        }

        [Test]
        public void Transform_StringToInt()
        {
            string[] array = new[] { "1", "2", "3", "4", "5" };
            int[] expected = { 1, 2, 3, 4, 5 };

            var actual = array.Transform(x => int.Parse(x));
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Transform_DoubleToInt()
        {
            double[] array = new[] { 1.133253, 19.9231475, -23.3253 };
            int[] expected = { 1, 19, -23 };

            var actual = array.Transform(x => (int)x);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Revers()
        {
            string[] array = new[] { "1", "2", "3", "4", "5" };
            string[] expected = new[] { "5", "4", "3", "2", "1" };

            var actual = array.Reverse();
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Range()
        {
            int[] expected = new[] { 5, 6, 7, 8, 9, 10 };

            var actual = Enumerable.Range(5, 6);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Filter_IntLargerThan7()
        {
            int[] array = new[] { 5, 6, 7, 8, 9, 10 };
            int[] expected = new[] { 8, 9, 10 };

            var actual = array.Filter(x => x > 7);
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Filter_StringLengthLargerThan7()
        {
            string[] array = new[] { "a", "aa", "aaa", "aaaaaaaaaaa" };
            string[] expected = new[] { "aaaaaaaaaaa" };

            var actual = array.Filter(x => x.Length > 7);
            Assert.AreEqual(actual, expected);
        }
    }
}