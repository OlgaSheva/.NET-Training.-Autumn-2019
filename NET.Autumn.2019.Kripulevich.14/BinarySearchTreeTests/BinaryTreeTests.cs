using BinarySearchTree;
using NUnit.Framework;
using System;
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

        #region Add tests

        [TestCase(new int[0], ExpectedResult = 0)]
        [TestCase(new int[] { 10, 5, 18, 2, 4, 1, 3 }, ExpectedResult = 7)]
        public int Add_AddItems_CheckCount(int[] source)
        {
            BinaryTree<int> bst = new BinaryTree<int>();

            foreach (var i in source)
            {
                bst.AddNode(i);
            }

            return bst.Count;
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

        #region IEnumerable InOrderWalkIterator tests

        [TestCase(new int[0], ExpectedResult = new int[0])]
        [TestCase(new int[] { 5, 2, 4, 1, 3 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 5, 3, 2, 4 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
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
    }
}