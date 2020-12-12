namespace DataStructures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataStructures.Data;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTreeUnitTests
    {
        [Test]
        public void Insert_Single_TraverseInOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(1);

            var nodes = new List<int>();
            bst.EachInOrder(nodes.Add);

            var expectedNodes = new int[] { 1 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
            Assert.AreEqual(expectedNodes.Length, bst.Count());
        }

        [Test]
        public void Insert_Multiple_TraverseInOrder()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);

            var nodes = new List<int>();
            bst.EachInOrder(nodes.Add);

            var expectedNodes = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
            Assert.AreEqual(expectedNodes.Length, bst.Count());
        }

        [Test]
        public void Delete_EmptyBST_ShouldThrowException()
        {
            var bst = new BinarySearchTree<int>();

            Assert.Throws(typeof(InvalidOperationException),
                () => bst.Delete(2), "Tree is empty!");
        }

        [Test]
        public void Delete_OneElementTree_ShouldMakeTreeEmpty()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(5);

            bst.Delete(5);

            var nodes = new List<int>();
            bst.EachInOrder(nodes.Add);
            int[] expectedNodes = new int[] { };
            CollectionAssert.AreEqual(expectedNodes, nodes);
            Assert.AreEqual(expectedNodes.Length, bst.Count());
        }

        [Test]
        public void Delete_SeveralElementsTree_ShouldWorkCorrectly()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(30);
            bst.Insert(25);
            bst.Insert(35);

            bst.Delete(10);
            bst.Delete(30);
            bst.Delete(80);

            var nodes = new List<int>();
            bst.EachInOrder(nodes.Add);
            var expectedNodes = new int[] { 5, 15, 17, 20, 25, 35 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
            Assert.AreEqual(expectedNodes.Length, bst.Count());
        }

        [Test]
        public void Contains_ExistingElement_ShouldReturnTrue()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);

            var contains = bst.Contains(3);

            Assert.IsTrue(contains);
        }

        [Test]
        public void Contains_NotExistingElement_ShouldReturnFalse()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);

            var contains = bst.Contains(7);

            Assert.IsFalse(contains);
        }

        [Test]
        public void Search_NonExistingElement_ShouldReturnEmptyTree()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);

            var result = bst.Search(5);
            var nodes = new List<int>();
            result.EachInOrder(nodes.Add);

            var expectedNodes = new int[] { };
            CollectionAssert.AreEqual(expectedNodes, nodes);
            Assert.AreEqual(expectedNodes.Length, result.Count());
        }

        [Test]
        public void Search_ExistingElement_ShouldReturnSubTree()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(30);
            bst.Insert(25);
            bst.Insert(35);

            var result = bst.Search(10);
            var nodes = new List<int>();
            result.EachInOrder(nodes.Add);

            var expectedNodes = new int[] { 5, 10, 15, 17 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void Range_ExistingElements_ShouldReturnCorrectElements()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(30);
            bst.Insert(25);
            bst.Insert(35);

            var result = bst.Range(5, 25);

            var expectedElements = new int[] { 5, 10, 15, 17, 20, 25};
            CollectionAssert.AreEqual(expectedElements, result.ToArray());
        }

        [Test]
        public void Range_ExistingElements_ShouldReturnCorrectCount()
        {
            var bst = new BinarySearchTree<int>();

            bst.Insert(20);
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(17);
            bst.Insert(30);
            bst.Insert(25);
            bst.Insert(35);

            var result = bst.Range(5, 25);

            var expectedElements = new int[] { 5, 10, 15, 17, 20, 25 };
            Assert.AreEqual(expectedElements.Length, result.ToArray().Length);
        }
    }
}