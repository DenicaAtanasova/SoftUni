namespace DataStructures.Tests
{
    using System.Collections.Generic;

    using NUnit.Framework;

    using DataStructures.Data;
    using System;

    [TestFixture]
    public class DoublyLinkedListUnitTests
    {
        #region Add methods tests
        [Test]
        public void AddFirst_EmptyList_ShouldAddElement()
        {
            var list = new DoublyLinkedList<int>();

            list.AddFirst(5);

            Assert.AreEqual(1, list.Count);
            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [Test]
        public void AddFirst_SeveralElements_ShouldAddElementsCorrectly()
        {
            var list = new DoublyLinkedList<int>();

            list.AddFirst(10);
            list.AddFirst(5);
            list.AddFirst(3);

            Assert.AreEqual(3, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 3, 5, 10 });
        }

        [Test]
        public void AddLast_EmptyList_ShouldAddElement()
        {
            var list = new DoublyLinkedList<int>();

            list.AddLast(5);

            Assert.AreEqual(1, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [Test]
        public void AddLast_SeveralElements_ShouldAddElementsCorrectly()
        {
            var list = new DoublyLinkedList<int>();

            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(15);

            Assert.AreEqual(3, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 5, 10, 15 });
        }
        #endregion

        #region Remove methods tests
        [Test]
        public void RemoveFirst_OneElement_ShouldMakeListEmpty()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(5);

            var element = list.RemoveFirst();

            Assert.AreEqual(5, element);
            Assert.AreEqual(0, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [Test]
        public void RemoveFirst_EmptyList_ShouldThrowException()
        {
            var list = new DoublyLinkedList<int>();

            Assert.Throws(typeof(InvalidOperationException), 
                () => list.RemoveFirst(), "List is empty!");
        }

        [Test]
        public void RemoveFirst_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);

            var element = list.RemoveFirst();

            Assert.AreEqual(5, element);
            Assert.AreEqual(2, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 6, 7 });
        }

        [Test]
        public void RemoveLast_OneElement_ShouldMakeListEmpty()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(5);

            var element = list.RemoveLast();

            Assert.AreEqual(5, element);
            Assert.AreEqual(0, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [Test]
        public void RemoveLast_EmptyList_ShouldThrowException()
        {
            var list = new DoublyLinkedList<int>();

            Assert.Throws(typeof(InvalidOperationException),
                () => list.RemoveFirst(), "List is empty!");
        }

        [Test]
        public void RemoveLast_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(10);
            list.AddFirst(9);
            list.AddFirst(8);

            var element = list.RemoveLast();

            Assert.AreEqual(10, element);
            Assert.AreEqual(2, list.Count);

            var items = new List<int>();
            list.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 8, 9 });
        }
        #endregion

        #region ForEach methods tests
        [Test]
        public void ForEach_EmptyList_ShouldEnumerateElementsCorrectly()
        {
            var list = new DoublyLinkedList<int>();

            var items = new List<int>();
            list.ForEach(items.Add);

            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [Test]
        public void ForEach_SingleElement_ShouldEnumerateElementsCorrectly()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(5);

            var items = new List<int>();
            list.ForEach(items.Add);

            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [Test]
        public void ForEach_MultipleElements_ShouldEnumerateElementsCorrectly()
        {
            var list = new DoublyLinkedList<string>();
            list.AddLast("Five");
            list.AddLast("Six");
            list.AddLast("Seven");

            var items = new List<string>();
            list.ForEach(items.Add);

            CollectionAssert.AreEqual(items,
                new List<string>() { "Five", "Six", "Seven" });
        }
        #endregion

        #region ToArray method tests
        [Test]
        public void ToArray_EmptyList_ShouldReturnEmptyArray()
        {
            var list = new DoublyLinkedList<string>();

            var arr = list.ToArray();

            CollectionAssert.AreEqual(arr, new string[] { });
        }

        [Test]
        public void ToArray_NonEmptyList_ShouldReturnArray()
        {
            var list = new DoublyLinkedList<string>();
            list.AddLast("Five");
            list.AddLast("Six");
            list.AddLast("Seven");

            var arr = list.ToArray();

            CollectionAssert.AreEqual(arr,
                new string[] { "Five", "Six", "Seven" });
        }
        #endregion

        #region IEnumerable mothod test
        [Test]
        public void IEnumerable_Foreach_MultipleElements()
        {
            var list = new DoublyLinkedList<string>();
            list.AddLast("Five");
            list.AddLast("Six");
            list.AddLast("Seven");

            var items = new List<string>();
            foreach (var element in list)
            {
                items.Add(element);
            }

            CollectionAssert.AreEqual(items,
                new List<string>() { "Five", "Six", "Seven" });
        }

        [Test]
        public void IEnumerable_NonGeneric_MultipleElements()
        {
            var list = new DoublyLinkedList<object>();
            list.AddLast("Five");
            list.AddLast(6);
            list.AddLast(7.77);

            var enumerator = list.GetEnumerator();
            var items = new List<object>();
            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Current);
            }

            CollectionAssert.AreEqual(items, new List<object>() { "Five", 6, 7.77 });
        }
        #endregion
    }
}