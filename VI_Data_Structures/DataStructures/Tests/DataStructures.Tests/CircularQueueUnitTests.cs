namespace DataStructures.Tests
{
    using System;
    using System.Linq;

    using DataStructures.Data;

    using NUnit.Framework;

    [TestFixture]
    public class CircularQueueUnitTests
    {
        #region Enqueue method tests
        [Test]
        public void Enqueue_EmptyQueue_ShouldAddElement()
        {
            CircularQueue<int> queue = new CircularQueue<int>();

            queue.Enqueue(5);

            Assert.AreEqual(1, queue.Count);
        }

        [Test]
        public void Enqueue1000Elements_ShouldWorkCorrectly()
        {
            CircularQueue<int> queue = new CircularQueue<int>();
            int numberOfElements = 1000;

            for (int i = 0; i < numberOfElements; i++)
            {
                queue.Enqueue(i);
                Assert.AreEqual(i + 1, queue.Count);
            }
        }

        [Test]
        public void InitialCapacity1_Enqueue20Elements_ShouldWorkCorrectly()
        {
            int elementsCount = 20;
            int initialCapacity = 1;

            CircularQueue<int> queue = new CircularQueue<int>(initialCapacity);
            for (int i = 0; i < elementsCount; i++)
            {
                queue.Enqueue(i);
            }

            Assert.AreEqual(elementsCount, queue.Count);
        }

        #endregion

        #region Dequeue method tests
        [Test]
        public void Dequeuе_ShouldWorkCorrectly()
        {
            CircularQueue<string> queue = new CircularQueue<string>();
            string element = "some value";

            queue.Enqueue(element);
            string elementFromQueue = queue.Dequeue();

            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(element, elementFromQueue);
        }

        [Test]
        public void Dequeue1000Elements_ShouldWorkCorrectly()
        {
            CircularQueue<int> queue = new CircularQueue<int>();
            int numberOfElements = 1000;

            for (int i = 0; i < numberOfElements; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(numberOfElements - i, queue.Count);
                int element = queue.Dequeue();
                Assert.AreEqual(i, element);
                Assert.AreEqual(numberOfElements - i - 1, queue.Count);
            }
        }

        [Test]
        public void Dequeue_EmptyQueue_ThrowsException()
        {
            CircularQueue<int> queue = new CircularQueue<int>();

            Assert.Throws(typeof(InvalidOperationException),
                () => queue.Dequeue(), "Queue is empty!");
        }
        #endregion

        #region ToArray method tests
        [Test]
        public void ToArray_500Elements__ShouldWorkCorrectly()
        {
            int[] array = Enumerable.Range(1, 500).ToArray();
            CircularQueue<int> queue = new CircularQueue<int>();

            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }
            int[] arrayFromQueue = queue.ToArray();

            CollectionAssert.AreEqual(array, arrayFromQueue);
        }
        #endregion
    }
}