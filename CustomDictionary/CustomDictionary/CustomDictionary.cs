using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    public class CustomDictionary
    {
        public int[] _keys;
        public string[] _values;
        private int _size;
        private const int _defaultCapacity = 32;

        public CustomDictionary()
        {
            _keys = new int[_defaultCapacity];
            _values = new string[_defaultCapacity];
            _size = 0;
        }

        private int GetIndex(int key)
        {
            return key % _keys.Length;
        }

        public void Add(int key, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("Значение не может быть пустым");
                return;
            }

            if (_size >= _keys.Length) Resize();

            int index = GetIndex(key);

            while (!String.IsNullOrEmpty(_values[index]) && _values[index] == value)
            {
                index = (index + 1) % _keys.Length;
            }

            _keys[index] = key;
            _values[index] = value;
            _size++;
        }

        private void Resize()
        {
            int newSize = _keys.Length * 2;
            int[] newKeys = new int[newSize];
            string[] newValues = new string[newSize];

            for (int i = 0; i < _keys.Length; i++)
            {
                if (_keys[i] != 0)
                {
                    int newIndex = _keys[i] % newSize;
                    while (newKeys[newIndex] != 0)
                    {
                        newIndex = (newIndex + 1) % newSize;
                    }
                    newKeys[newIndex] = _keys[i];
                    newValues[newIndex] = _values[i];
                }
            }

            _keys = newKeys;
            _values = newValues;
        }

        public string Get(int key)
        {
            int index = GetIndex(key);

            while (_keys[index] != 0)
            {
                if (_keys[index] == key)
                    return _values[index];

                index = (index + 1) % _keys.Length;
            }

            throw new Exception("Ключ не найден!");
        }

        public string this[int key]
        {
            get => Get(key);
            set => Add(key, value);
        }
    }
}
