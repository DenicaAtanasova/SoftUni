namespace DataStructures.Tests
{
    using DataStructures.Data;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class BinaryHeapUnitTests
    {
        [Test]
        public void Insert_SingleElement_ShouldWorkCorrectly()
        {
            var heap = new BinaryHeap<int>();

            heap.Insert(5);

            Assert.AreEqual(1, heap.Count(), "Wrong count");
        }

        [Test]
        public void Insert_MultipleElements_ShouldWorkCorrectly()
        {
            var heap = new BinaryHeap<int>();

            heap.Insert(5);
            heap.Insert(15);
            heap.Insert(10);

            Assert.AreEqual(3, heap.Count(), "Wrong count");
        }

        [Test]
        public void Peek_SingleElement_ShouldWorkCorrectly()
        {
            var heap = new BinaryHeap<int>();

            heap.Insert(5);

            Assert.AreEqual(5, heap.Peek(), "Wrong item");
        }

        [Test]
        public void Peek_MultipleElements_ShouldWorkCorrectly()
        {
            var heap = new BinaryHeap<int>();

            heap.Insert(5);
            Assert.AreEqual(5, heap.Peek(), "Wrong item");

            heap.Insert(15);
            Assert.AreEqual(15, heap.Peek(), "Wrong item");

            heap.Insert(10);
            Assert.AreEqual(15, heap.Peek(), "Wrong item");

            heap.Insert(25);
            Assert.AreEqual(25, heap.Peek(), "Wrong item");
        }

        [Test]
        public void Pull_EmptyHeap_ShouldThrowException()
        {
            var heap = new BinaryHeap<int>();

            Assert.Throws(typeof(InvalidOperationException), 
                () => heap.Pull(), "Heap is empty!");
        }

        [Test]
        public void Pull_ShouldThrowException()
        {
            var heap = new BinaryHeap<int>();

            heap.Insert(5);
            heap.Insert(15);
            heap.Insert(10);
            heap.Insert(25);

            Assert.AreEqual(25, heap.Pull(), "Wrong item");
            Assert.AreEqual(3, heap.Count(), "Wrong count");
            Assert.AreEqual(15, heap.Peek(), "Wrong item");

            Assert.AreEqual(15, heap.Pull(), "Wrong item");
            Assert.AreEqual(2, heap.Count(), "Wrong count");
            Assert.AreEqual(10, heap.Peek(), "Wrong item");

            Assert.AreEqual(10, heap.Pull(), "Wrong item");
            Assert.AreEqual(1, heap.Count(), "Wrong count");
            Assert.AreEqual(5, heap.Peek(), "Wrong item");
        }
    }
}