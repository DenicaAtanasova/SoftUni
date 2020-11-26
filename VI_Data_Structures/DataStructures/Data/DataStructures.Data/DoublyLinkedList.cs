namespace DataStructures.Data
{
    using DataStructures.Data.Contracts;

    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>, IDoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var newHead = new Node<T>(element);

            if (this.Count == 0)
            {
                this.tail = newHead;
            }
            else
            {
                newHead.Next = this.head;
                this.head.Prev = newHead;
            }

            this.head = newHead;
            this.Count++;
        }

        public void AddLast(T element)
        {
            var newTail = new Node<T>(element);

            if (this.Count == 0)
            {
                this.head = newTail;
            }
            else
            {
                this.tail.Next = newTail;
                newTail.Prev = this.tail;
            }

            this.tail = newTail;
            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!"); 
            }

            var removedItem = this.head.Value;
            this.head = this.head.Next;

            this.Count--;
            if (this.Count != 0)
            {
                this.head.Prev = null;
            }
            else
            {
                this.tail = null;
            }

            return removedItem;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            var removedItem = this.tail.Value;
            this.tail = this.tail.Prev;

            this.Count--;
            if (this.Count != 0)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }

            return removedItem;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            var cuurentElement = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = cuurentElement.Value;
                cuurentElement = cuurentElement.Next;
            }

            return array;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node<T>
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node<T> Next { get; set; }

            public Node<T> Prev { get; set; }
        }
    }
}