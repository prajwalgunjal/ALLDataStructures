using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class CustomList<T>
    {
        private T[] _items;
        private int _count;

        public CustomList(int size)
        {
            _items = new T[size]; // Initial capacity
            _count = 0;
        }

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count++] = item;
        }

        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();
            return _items[index];
        }

        public int Count => _count;
    }
}
