namespace DataStructures.Data
{
    using DataStructures.Data.Contracts;
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T: IComparable
    {
        private Node root;

        public BinarySearchTree()
        {
            this.root = null;       
        }

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public void Insert(T value)
        {
            if (this.root == null)
            {
                this.root = new Node(value);
            }
            else
            {
                this.Insert(this.root, value);
            }
        }

        public void Delete(T value)
        {
            if (this.root == null)
            {
                throw new InvalidOperationException("Tree is empty!");
            }

            this.root = this.Delete(this.root, value);
        }

        public int Count() 
        {
            var count = 0;
            if (this.root != null)
            {
                count = this.Count(this.root);
            }

            return count;
        }

        public void EachInOrder(Action<T> action)
        {
            if (this.root == null)
            {
                return;
            }
            else
            {
                this.EachInOrder(this.root, action);
            }
        }

        public bool Contains(T value)
        {
            var currentNode = this.FindNode(value);
            return currentNode != null;
        }

        public IBinarySearchTree<T> Search(T value)
        {
            var currentNode = this.FindNode(value);
            return new BinarySearchTree<T> (currentNode);
        }

        public IEnumerable<T> Range(T minValue, T maxValue)
        {
            var queue = new Queue<T>();
            this.Range(this.root, queue, minValue, maxValue);

            return queue;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(Node node, T value)
        {
            if (node == null)
            {
                return new Node(value);
            }

            var compare = node.Value.CompareTo(value);

            if (compare > 0)
            {
                node.Left = this.Insert(node.Left, value);
            }
            else if (compare < 0)
            {
                node.Right = this.Insert(node.Right, value);
            }

            return node;
        }

        private int Count(Node node)
        {
            if (node == null)
                return 0;

            var count = 1 + this.Count(node.Left) + this.Count(node.Right);
            return count;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private Node Delete(Node node, T value)
        {
            if (node == null)
            {
                return node;
            }

            var compare = node.Value.CompareTo(value);
            if (compare > 0)
            {
                node.Left = this.Delete(node.Left, value);
            }
            else if (compare < 0)
            {
                node.Right = this.Delete(node.Right, value);
            }
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                else if(root.Right == null)
                {
                    return node.Left;
                }

                node.Value = this.FindMinValue(node.Right);
                node.Right = this.Delete(node.Right, node.Value);
            }

            return node;
        }

        private T FindMinValue(Node node)
        {
            var minLeaf = node;
            while (minLeaf.Left != null)
            {
                minLeaf = minLeaf.Left;
            }

            return minLeaf.Value;
        }

        private Node FindNode(T value)
        {
            var currentNode = this.root;
            while (currentNode != null)
            {
                var compare = currentNode.Value.CompareTo(value);
                if (compare > 0)
                {
                    currentNode = currentNode.Left;
                }
                else if (compare < 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    break;
                }
            }

            return currentNode;
        }

        private void Range(Node node, Queue<T> queue, T minValue, T maxValue)
        {
            if (node == null)
            {
                return;
            }

            var nodeInMinRange = minValue.CompareTo(node.Value);
            var nodeInMaxRange = maxValue.CompareTo(node.Value);

            if (nodeInMinRange < 0)
            {
                this.Range(node.Left, queue, minValue, maxValue);
            }

            if (nodeInMinRange <= 0 && nodeInMaxRange >= 0)
            {
                queue.Enqueue(node.Value);
            }

            if (nodeInMaxRange > 0)
            {
                this.Range(node.Right, queue, minValue, maxValue);
            }
        }

        private class Node 
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }
    }
}