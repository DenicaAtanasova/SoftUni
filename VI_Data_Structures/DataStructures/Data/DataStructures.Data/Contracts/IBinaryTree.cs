namespace DataStructures.Data.Contracts
{
    using System;

    public interface IBinaryTree<T>
    {
        void PrintIndentedPreOrder(int indent = 0);

        void EachInOrder(Action<T> action);

        void EachPostOrder(Action<T> action);
    }
}