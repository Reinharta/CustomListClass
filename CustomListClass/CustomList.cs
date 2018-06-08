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
                {
                    return myArray[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            set
            {
                if (index >= 0 && index <= (capacity - 1))
                {
                    myArray[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add (T value)
        {
            myArray[count] = value;
            count++;
            MaintainCapacity();
        }
        public void Remove(T value)
        {
            for (int i = 0; i <= count; i++)
            {
                if(myArray[i].Equals(value))
                {
                    for (int j = 0; j <= count; i++)  //issue: will shift ALL indexes, even those before removed item
                    {
                        myArray[j] = myArray[j++];
                    }
                    //myArray[i] = default(T);
                    count--;
                }
            }
            
            MaintainCapacity();
        }

        private void MaintainCapacity()
        {
            if (count == (capacity * 0.6))
                {capacity = (capacity * 2); }
            if (capacity > 5 && count < (capacity * 0.3))
                {capacity = (capacity / 2);}
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
