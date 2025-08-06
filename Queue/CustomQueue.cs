using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class CustomQueue<T>
    {
        private T[] _items;
        private int _front;
        private int _rear;
        private int _count;
        private int _capacity;
        public bool IsEmpty => _count == 0;
        public int Count => _count;
        public CustomQueue(int capacity = 4)
        {
            _capacity = capacity;
            _items = new T[_capacity];
            _front = 0;
            _rear = -1;
            _count = 0;
        }

        public void Enqueue(T item)
        {
            if (_count == _capacity)
            {
                Resize();
            }

            _rear = (_rear + 1) % _capacity;
            _items[_rear] = item;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            T value = _items[_front];
            _front = (_front + 1) % _capacity;
            _count--;
            return value;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            return _items[_front];
        }
        private void Resize()
        {
            int newCapacity = _capacity * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[(_front + i) % _capacity];
            }

            _items = newArray;
            _capacity = newCapacity;
            _front = 0;
            _rear = _count - 1;
        }
    }
}
