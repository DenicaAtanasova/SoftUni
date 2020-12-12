namespace DataStructures.Data.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IBinarySearchTree<T>
        where T: IComparable
    {
        void Insert(T value);

        void Delete(T value);

        bool Contains(T value);

        public int Count();

        void EachInOrder(Action<T> action);

        IBinarySearchTree<T> Search(T value);

        IEnumerable<T> Range(T minValue, T maxValue);
    }
}