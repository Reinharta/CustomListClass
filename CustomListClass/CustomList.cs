using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    public class CustomList<T> : IEnumerable<T>
    {
        public T[] myArray;
        public int capacity;
        public int count;

        public CustomList()
        {
            capacity = 5;
            myArray = new T[capacity];
            for (int i = 0; i < capacity; i++)
                myArray[i] = default(T);
        }

        public T this [int index]
        {
            get
            {
                if (index >= 0 && index <= (capacity - 1))
                    throw new IndexOutOfRangeException("Index out of range");

                return myArray[index];
            }
            set
            {
                if (index >= 0 && index <= (capacity - 1))
                    throw new IndexOutOfRangeException("Index out of range");

                myArray[index] = value;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add (T value)
        {
            for (int i = 0; i < capacity; i++)
            {
                if(EqualityComparer<T>.Default.Equals(myArray[i], default(T)))
                {
                    myArray[i] = value;
                    count++;
                    break;
                }
            }
            MaintainCapacity();
        }

        private void MaintainCapacity()
        {
            if (count == (capacity * 0.6))
            {
                capacity = (capacity * 2);
            }
            if (capacity > 5 && count <= (capacity * 0.4))
            {
                capacity = (capacity / 2);
            }
        }

        public void Remove (T value)
        {

            MaintainCapacity();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
