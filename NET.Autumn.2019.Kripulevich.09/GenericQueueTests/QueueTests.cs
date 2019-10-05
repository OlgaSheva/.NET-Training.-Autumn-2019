using NUnit.Framework;
using GenericQueue;

namespace GenericQueueTests
{
    public class QueueTests
    {
        [Test]
        public void Queue_Initialize()
        {
            var queue = new Queue<int>();
            var expected = new int[0];

            var actual = queue.ToArray();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Queue_InitializeCapacity()
        {
            var queue = new Queue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            var expected = new int[] { 1, 2, 3 };

            var actual = queue.ToArray();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Queue_InitializeIEnumerable()
        {
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            System.Collections.Generic.IEnumerable<int> collection = expected;

            var queue = new Queue<int>(collection);          
            var actual = queue.ToArray();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Queue_Dequeue_HeadItem()
        {
            System.Collections.Generic.IEnumerable<int> collection = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Queue<int> queue = new Queue<int>(collection);
            int actual = queue.Dequeue();

            Assert.AreEqual(actual, 1);
            Assert.IsFalse(queue.Contains(1));
        }

        [Test]
        public void Queue_Peek_HeadItem()
        {
            System.Collections.Generic.IEnumerable<int> collection = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Queue<int> queue = new Queue<int>(collection);
            queue.Dequeue();
            int actual = queue.Peek();

            Assert.AreEqual(actual, 2);
            Assert.IsTrue(queue.Contains(2));
        }

        [Test]
        public void Queue_Clear_EmptyQueue()
        {
            System.Collections.Generic.IEnumerable<int> collection = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Queue<int> queue = new Queue<int>(collection);
            queue.Clear();
            var actual = queue.ToArray();

            Assert.AreEqual(actual, new int[0]);
        }
    }
}