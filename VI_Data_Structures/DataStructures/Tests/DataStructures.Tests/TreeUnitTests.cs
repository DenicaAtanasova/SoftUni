namespace DataStructures.Tests
{
    using System.IO;
    using System;
    using System.Text;
    using System.Collections.Generic;

    using NUnit.Framework;

    using DataStructures.Data;

    [TestFixture]
    public class TreeUnitTests
    {
        private Tree<int> tree;
        public TreeUnitTests()
        {
            this.tree = new Tree<int>(7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6)));
        }

        #region Print method tests
        [Test]
        public void Print_ShouldWorkCorrectly()
        {
            var outputStream = new MemoryStream();
            using (var outputWriter = new StreamWriter(outputStream))
            {
                Console.SetOut(outputWriter);
                this.tree.Print();
            }
            var output = Encoding.UTF8.GetString(outputStream.ToArray());

            var expectedOutput = "7\n  19\n    1\n    12\n    31\n  21\n  14\n    23\n    6\n";
            output = output.Replace("\r\n", "\n");
            Assert.AreEqual(expectedOutput, output);
        }
        #endregion

        #region Each method tests
        [Test]
        public void Each_ShouldWorkCorrectly()
        { 
            var nodes = new List<int>();
            this.tree.Each(nodes.Add);
          
            var expectedNodes = new int[] { 7, 19, 1, 12, 31, 21, 14, 23, 6 };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }
        #endregion

        #region OrderDFS method tests
        [Test]
        public void OrderDFS_SingleElement_ShouldWordCorrectly()
        {
            var tree = new Tree<int>(7);

            var actual = new List<int>(tree.OrderDFS());

            var expectedOutput = new List<int>() { 7 };
            CollectionAssert.AreEqual(expectedOutput, actual);
        }

        [Test]
        public void OrderDFS_MultipleElements_ShouldWordCorrectly()
        {
            var actual = new List<int>(this.tree.OrderDFS());

            var expectedOutput = new List<int>() { 1, 12, 31, 19, 21, 23, 6, 14, 7 };
            CollectionAssert.AreEqual(expectedOutput, actual);
        }
        #endregion

        #region OrderBFS method tests
        [Test]
        public void OrderBFS_SingleElement_ShouldWorkCorrectly()
        {
            var tree =
                new Tree<int>(7);

            var actual = new List<int>(tree.OrderBFS());

            var expectedOutput = new List<int>() { 7 };
            CollectionAssert.AreEqual(expectedOutput, actual);
        }

        [Test]
        public void OrderBFS_MultipleElements_ShouldWorkCorrectly()
        {
            var actual = new List<int>(this.tree.OrderBFS());

            var expectedOutput = new List<int>() { 7, 19, 21, 14, 1, 12, 31, 23, 6 };
            CollectionAssert.AreEqual(expectedOutput, actual);
        }
        #endregion
    }
}