using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    public class CustomList<T>
    {
        public T[] array;
        int capacity;

        public CustomList()
        {
            capacity = 5;
            array = new T[capacity];
        }

        public void Add (T value)
        {

        }

        public void Remove (T value)
        {

        }


    }
}
