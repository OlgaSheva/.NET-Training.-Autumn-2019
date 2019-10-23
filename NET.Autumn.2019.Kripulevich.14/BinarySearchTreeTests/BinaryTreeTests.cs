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
        public void ConstructorWithoutParametersTest()
        {
            BinaryTree<int> bst = new BinaryTree<int>();
            Assert.NotNull(bst);
        }

        [Test]
        public void ConstructorWithIComparerAsParameterTest_IfArgumentIsNull_Throw_ArgumentNullException()
        {
            IComparer<int> comparer = null;
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<int>(comparer));
        }

        [Test]
        public void ConstructorWithIEnumerableAsParameterTest_IfIEnumerableIsNull_Throw_ArgumentNullException()
        {
            IEnumerable<int> source = null;
            IComparer<int> comparer = Comparer<int>.Default;
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<int>(source, comparer));
        }

        [Test]
        public void ConstructorWithIEnumerableAsParameterTest_SetCollectionAsParameter_CheckCount()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3 };
            BinaryTree<int> bst = new BinaryTree<int>(source);

            Assert.AreEqual(3, bst.Count);
        }

        [Test]
        public void ConstructorWithIEnumerableAndIComparerAsParameterTest_IfIComparerIsNull_Throw_ArgumentNullException()
        {
            IEnumerable<int> source = new int[] { 1, 2, 3 };
            IComparer<int> comparer = null;
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<int>(source, comparer));
        }

        #endregion

        #region Add test

        [TestCase(new int[0], ExpectedResult = 0)]
        [TestCase(new int[] { 10, 5, 18, 2, 4, 1, 3 }, ExpectedResult = 7)]
        public int AddTests_AddItems_CheckCount(int[] source)
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

        [TestCase(new int[0], 5, ExpectedResult = false)]
        [TestCase(new int[] { 42 }, 42, ExpectedResult = true)]
        [TestCase(new int[] { 10, 5, 18, 2, 4, 1, 3 }, 10, ExpectedResult = true)]
        public bool ContainsTests(int[] source, int item)
        {
            BinaryTree<int> bst = new BinaryTree<int>(source);

            return bst.Contains(item);
        }

        #endregion

        #region IEnumerable InOrderWalkIterator tests

        [TestCase(new int[0], ExpectedResult = new int[0])]
        [TestCase(new int[] { 10, 5, 18, 2, 4, 1, 3 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 10, 18 })]
        [TestCase(new int[] { 1, 5, 18, 3, 10, 2, 4 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 10, 18 })]
        public IEnumerable<int> IEnumerableImplementationTests_AddItems_Check_EnumeratorReturnsValuesInCorrectOrder(int[] source)
        {
            BinaryTree<int> bst = new BinaryTree<int>();

            foreach (var i in source)
            {
                bst.AddNode(i);
            }

            return bst;
        }

        #endregion

        
    }
}