namespace DataStructures.Data
{
    using Contracts;

    using System;
    using System.Collections.Generic;

    public class BinaryHeap<T> : IBinaryHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public int Count() => this.heap.Count;

        public void Insert(T item)
        {
            this.heap.Add(item);
            this.HeapifyUp(this.heap.Count - 1);
        }

        public T Peek() => this.heap[0];

        public T Pull()
        {
            if (this.Count() <= 0)
            {
                throw new InvalidOperationException("Heap is empty!");
            }

            var item = this.heap[0];
            this.Swap(this.heap.Count - 1, 0);
            this.heap.RemoveAt(this.heap.Count - 1);
            this.HeapifyDown(0);

            return item;
        }

        private void HeapifyDown(int index)
        {
            while (index < this.heap.Count/2)
            {
                var childIndex = Left(index);
                if (HasChild(childIndex + 1) && IsLess(childIndex, childIndex + 1))
                {
                    childIndex++;
                }

                if (IsLess(childIndex, index))
                {
                    break;
                }

                this.Swap(index, childIndex);
                index = childIndex;
            }
        }

        private bool HasChild(int index) => 
            this.heap.Count > index;

        private int Left(int index) =>
            2 * index + 1;

        private void HeapifyUp(int index)
        {
            while (index > 0 && IsLess(GetParentIndex(index), index))
            {
                this.Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private void Swap(int childIndex, int parentIndex)
        {
            var child = this.heap[childIndex];
            this.heap[childIndex] = this.heap[parentIndex];
            this.heap[parentIndex] = child;
        }

        private bool IsLess(int firstItemIndex, int secondItemIndex) =>
            this.heap[firstItemIndex].CompareTo(this.heap[secondItemIndex]) < 0;

        private int GetParentIndex(int index) =>
            (index - 1) / 2;
    }
}