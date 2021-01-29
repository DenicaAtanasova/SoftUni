namespace DataStructures.Data.Contracts
{
    using System;

    public interface IBinaryHeap<T>
        where T : IComparable<T>
    {
        void Insert(T item);

        T Peek();

        T Pull();

        int Count();
    }
}