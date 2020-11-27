namespace DataStructures.Data
{
    using DataStructures.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryTree(T value, 
            IBinaryTree<T> leftChild = null, 
            IBinaryTree<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public void PrintIndentedPreOrder(int indent = 0)
        {
            Console.Write(new string(' ', 2 * indent));
            Console.WriteLine(this.Value);

            if (this.LeftChild != null)
            {
                this.LeftChild.PrintIndentedPreOrder(indent + 1);
            }

            if (this.RightChild != null)
            {
                this.RightChild.PrintIndentedPreOrder(indent + 1);
            }
        }

        public T Value { get; set; }

        public IBinaryTree<T> LeftChild { get; set; }

        public IBinaryTree<T> RightChild { get; set; }

        public void EachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.EachInOrder(action);
            }

            action(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.EachInOrder(action);
            }
        }

        public void EachPostOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.EachPostOrder(action);
            }

            if (this.RightChild != null)
            {
                this.RightChild.EachPostOrder(action);
            }

            action(this.Value);
        }
    }
}