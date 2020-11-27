namespace DataStructures.Data.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ITree<T>
    {
        void Print(int indent = 0);

        void Each(Action<T> action);

        IEnumerable<T> OrderDFS();

        IEnumerable<T> OrderBFS();
    }
}