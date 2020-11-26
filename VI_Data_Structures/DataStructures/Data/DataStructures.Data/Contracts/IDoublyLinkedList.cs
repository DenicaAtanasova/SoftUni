namespace DataStructures.Data.Contracts
{
    using System;

    public interface IDoublyLinkedList<T>
    {
        void AddFirst(T element);

        void AddLast(T element);

        T RemoveFirst();

        T RemoveLast();

        void ForEach(Action<T> action);

        T[] ToArray();
    }
}