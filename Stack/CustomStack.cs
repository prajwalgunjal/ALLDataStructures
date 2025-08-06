using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class CustomStack<T>
    {
        private T[] _items;
        private int _top;  // Points to next free spot
        private int _capacity;
        public CustomStack(int capacity = 4)
        {
            _capacity = capacity;
            _items = new T[_capacity];
            _top = 0;
        }
        public void Push(T item)
        {
            if (_top == _capacity)
                Resize();
            _items[_top] = item;
            _top++;
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");
            _top--;
            return _items[_top];
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");
            return _items[_top - 1];
        }
        public bool IsEmpty => _top == 0;
        public int Count => _top;
        private void Resize()
        {
            int newCapacity = _capacity * 2;
            T[] newArray = new T[newCapacity];
            for (int i = 0; i < _capacity; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
            _capacity = newCapacity;
        }
    }
}
