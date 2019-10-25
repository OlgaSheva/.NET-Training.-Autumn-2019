using BinarySearchTree;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeTests
{
    public class BinaryTreeTests
    {
        #region Constructors tests

        [Test]
        public void ConstructorWithoutParameters()
        {
            BinaryTree<int> bst = new BinaryTree<int>();
            Assert.NotNull(bst);
        }

        [Test]
        public void ConstructorWithIComparer_NullArgument_ArgumentNullException()
        {
            IComparer<int> comparer = null;
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<int>(comparer));
        }

        [Test]
        public void ConstructorWithIEnumerableAndIcomparer_NullIEnumerable_ArgumentNullException()
        {
            IEnumerable<int> source = null;
            IComparer<int> comparer = Comparer<int>.Default;
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<int>(source, comparer));
        }

        [Test]
        public void ConstructorWithIEnumerable_Collection_CheckCount()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3 };
            BinaryTree<int> bst = new BinaryTree<int>(source);

            Assert.AreEqual(3, bst.Count);
        }

        [Test]
        public void ConstructorWithIEnumerableAndIComparer_NullIComparer_ArgumentNullException()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3 };
            IComparer<int> comparer = null;
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<int>(source, comparer));
        }

        #endregion

        #region Add and delete tests

        [TestCase(new int[0], ExpectedResult = 0)]
        [TestCase(new int[] { 10, 5, 18, 2, 4, 1, 3 }, ExpectedResult = 7)]
        public int Add_AddItems_CheckCount(int[] source)
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            foreach (var i in source)
            {
                tree.AddNode(i);
            }

            return tree.Count;
        }

        [TestCase(new int[] { 10, 5, 18, 2, 4, 1, 3 }, ExpectedResult = 5)]
        [TestCase(new int[] { 10, 5, 18, 2, 4, 1, 3, 19, -5, -1 }, ExpectedResult = 8)]
        public int Delet_DeletItems_CheckCount(int[] source)
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            foreach (var i in source)
            {
                tree.AddNode(i);
            }

            tree.Delete(5);
            tree.Delete(1);

            return tree.Count;
        }

        #endregion

        #region Contains tests

        [TestCase(new int[0], 1, ExpectedResult = false)]
        [TestCase(new int[] { 42 }, 42, ExpectedResult = true)]
        [TestCase(new int[] { 42, 12, 10, -40, 65 }, 10, ExpectedResult = true)]
        public bool ContainsTests(int[] source, int item)
        {
            BinaryTree<int> bst = new BinaryTree<int>(source);

            return bst.Contains(item);
        }

        #endregion

        #region InOrderWalkIterator tests

        [TestCase(new int[0], ExpectedResult = new int[0])]
        [TestCase(new int[] { 5, 4, 9, 3, 8, 15, 1, 6, 10, 7 }, ExpectedResult = new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 15 })]
        [TestCase(new int[] { 5, 4, 15, 3, 8, 30, -30, 0, 1, 2 }, ExpectedResult = new int[] { -30, 0, 1, 2, 3, 4, 5, 8, 15, 30 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8 }, ExpectedResult = new int[] { 4, 5, 6, 7, 8 })]
        public IEnumerable<int> IEnumerableImplementation_AddItems_ValuesInCorrectOrder(int[] source)
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            foreach (var i in source)
            {
                tree.AddNode(i);
            }

            return tree;
        }

        #endregion

        #region PreOrderWalkIterator tests

        [TestCase(new int[0], ExpectedResult = new int[0])]
        [TestCase(new int[] { 5, 4, 9, 3, 8, 15, 1, 6, 10, 7 }, ExpectedResult = new int[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 })]
        [TestCase(new int[] { 5, 4, 15, 3, 8, 30, -30, 0, 1, 2 }, ExpectedResult = new int[] { 5, 4, 3, -30, 0, 1, 2, 15, 8, 30 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8 }, ExpectedResult = new int[] { 4, 5, 6, 7, 8 })]
        public IEnumerable<int> PreOrderWalkIterator_AddItems_ValuesInCorrectOrder(int[] source)
        {
            BinaryTree<int> tree = new BinaryTree<int>(source);
            var result = new List<int>();
            var e = tree.PreOrderTraversal();
            while (e.MoveNext())
            {
                result.Add(e.Current);
            }

            return result.ToArray();
        }

        #endregion

        #region PostOrderWalkIterator tests

        [TestCase(new int[0], ExpectedResult = new int[0])]
        [TestCase(new int[] { 5, 4, 9, 3, 8, 15, 1, 6, 10, 7 }, ExpectedResult = new int[] { 15, 10, 9, 8, 7, 6, 5, 4, 3, 1 })]
        [TestCase(new int[] { 5, 4, 15, 3, 8, 30, -30, 0, 1, 2 }, ExpectedResult = new int[] { 30, 15, 8, 5, 4, 3, 2, 1, 0, -30 })]
        [TestCase(new int[] { 4, 5, 6, 7, 8 }, ExpectedResult = new int[] { 8, 7, 6, 5, 4 })]
        public IEnumerable<int> PostOrderWalkIterator_AddItems_ValuesInCorrectOrder(int[] source)
        {
            BinaryTree<int> tree = new BinaryTree<int>(source);
            var result = new List<int>();
            var e = tree.PostOrderTraversal();
            while (e.MoveNext())
            {
                result.Add(e.Current);
            }

            return result.ToArray();
        }

        #endregion

        #region Task tests

        [TestCase(new int[0], ExpectedResult = new int[0])]
        [TestCase(new int[] { 10, 5, 18, 2, 4, 1, 3 }, ExpectedResult = new int[] { 18, 10, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 5, 18, 3, 10, 2, 4 }, ExpectedResult = new int[] { 18, 10, 5, 4, 3, 2, 1 })]
        public IEnumerable<int> TreeWithSpecifiedComparer_IntItems_ValuesInCorrectOrder(int[] source)
        {
            var comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
            BinaryTree<int> tree = new BinaryTree<int>(source, comparer);
            return tree;
        }

        [TestCase(new object[0], ExpectedResult = new string[0])]
        [TestCase(new object[] { "one", "two ", "forty two", "zero" }, ExpectedResult = new string[] { "forty two", "one", "two ", "zero" })]
        [TestCase(new object[] { "K", "F", "U", "B", "A", "Z" }, ExpectedResult = new string[] { "A", "B", "F", "K", "U", "Z" })]
        public IEnumerable<string> TreeWithDefaultComparer_StringItems_ValuesInCorrectOrder(params string[] source)
        {
            BinaryTree<string> tree = new BinaryTree<string>(source);
            return tree;
        }

        [TestCase(new object[0], ExpectedResult = new string[0])]
        [TestCase("one", "forty two", "zero" , ExpectedResult = new string[] { "one", "zero", "forty two" })]
        [TestCase("KKKK", "Ff", "UUUUUUU", "BBBBBBBBB", "A", "ZZzZZ", ExpectedResult = new string[] { "A", "Ff", "KKKK", "ZZzZZ", "UUUUUUU", "BBBBBBBBB" })]
        public IEnumerable<string> TreeWithSpecifiedComparer_StringItems_ValuesInCorrectOrder(params string[] source)
        {
            var comparer = Comparer<string>.Create((x, y) => x.Length.CompareTo(y.Length));
            BinaryTree<string> tree = new BinaryTree<string>(source, comparer);
            return tree;
        }

        [Test]
        public void TreeWithDefaultComparer_Books_ValuesInCorrectOrder()
        {
            List<Book> source = new List<Book> {
                new Book("Jeffrey Richter", "CLR via C#", 2012),
                new Book("Jon Skeet", "C# in Depth", 2013),
                new Book("Joseph Albahari", "C# 7.0 in a Nutshell: The Definitive Reference", 2018),
                new Book("Bart De Smet", "C# 5.0 Unleashed", 2013),
                new Book("Dino Esposito", "Programming Microsoft ASP.NET MVC", 2014)};
            List<Book> expected = source;
            expected.Sort();

            CollectionAssert.AreEqual(expected, new BinaryTree<Book>(source));
        }

        [Test]
        public void TreeWithSpecifiedComparer_Books_ValuesInCorrectOrder()
        {
            List<Book> source = new List<Book> {
                new Book("Jeffrey Richter", "CLR via C#", 2012),
                new Book("Jon Skeet", "C# in Depth", 2013),
                new Book("Joseph Albahari", "C# 7.0 in a Nutshell: The Definitive Reference", 2018),
                new Book("Bart De Smet", "C# 5.0 Unleashed", 2013),
                new Book("Dino Esposito", "Programming Microsoft ASP.NET MVC", 2014)};
            List<Book> expected = source;
            var comparer = Comparer<Book>.Create((x, y) => x.Author.CompareTo(y.Author));
            expected.Sort(comparer);

            CollectionAssert.AreEqual(expected, new BinaryTree<Book>(source, comparer));
        }

        [Test]
        public void TreeWithSpecifiedComparer_Points_ValuesInCorrectOrder()
        {
            List<Point> source = new List<Point>() {
                new Point(100, 100),
                new Point(-50, 50),
                new Point(0, 0),
                new Point(-20, 50),
                new Point(20, 1120) };
            var comparer = Comparer<Point>.Create((x, y) => x.X.CompareTo(y.X));
            var tree = new BinaryTree<Point>(source, comparer);
            List<Point> expected = source;
            expected.Sort(comparer);

            CollectionAssert.AreEqual(expected, tree);
        }

        #endregion
    }
}