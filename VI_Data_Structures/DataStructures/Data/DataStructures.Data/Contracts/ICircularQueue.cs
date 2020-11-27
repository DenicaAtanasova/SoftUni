namespace DataStructures.Data.Contracts
{
    public interface ICircularQueue<T>
    {
        void Enqueue(T element);

        T Dequeue();

        T[] ToArray();
    }
}