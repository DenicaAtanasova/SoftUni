namespace DataStructures.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using NUnit.Framework;

    using DataStructures.Data.Contracts;
    using DataStructures.Data;
    using System.IO;

    [TestFixture]
    public class BinaryTreeUnitTests
    {
        private IBinaryTree<string> binaryTree;

        public BinaryTreeUnitTests()
        {
            this.binaryTree =
                new BinaryTree<string>("*",
                    new BinaryTree<string>("+",
                        new BinaryTree<string>("3"),
                        new BinaryTree<string>("2")),
                    new BinaryTree<string>("-",
                        new BinaryTree<string>("9"),
                        new BinaryTree<string>("6")));
        }

        [Test]
        public void PrintIndentedPreOrder_ShouldWorkCorrectly()
        {
            var outputStream = new MemoryStream();
            using (var outputWriter = new StreamWriter(outputStream))
            {
                Console.SetOut(outputWriter);
                this.binaryTree.PrintIndentedPreOrder();
            }
            var output = Encoding.UTF8.GetString(outputStream.ToArray());

            var expectedOutput = "*\n  +\n    3\n    2\n  -\n    9\n    6\n";
            output = output.Replace("\r\n", "\n");
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void EachInOrder_ShouldWorkCorrectly()
        {
            var nodes = new List<string>();
            this.binaryTree.EachInOrder(nodes.Add);

            var expectedNodes = new string[] { "3", "+", "2", "*", "9", "-", "6" };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }

        [Test]
        public void EachPostOrder_ShouldWorkCorrectly()
        {
            var nodes = new List<string>();
            this.binaryTree.EachPostOrder(nodes.Add);

            var expectedNodes = new string[] { "3", "2", "+", "9", "6", "-", "*" };
            CollectionAssert.AreEqual(expectedNodes, nodes);
        }
    }
}
