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
        private T[] myArray;
        private T[] tempArray;
        private int capacity;
        private int count;

        public T[] MyArray
        {
            get { return myArray; }
            set { myArray = value; }
        }
        public int Capacity
        {
            get { return capacity; }
        }
        public int Count
        {
            get { return count; }
        }

        public CustomList()
        {
            capacity = 5;
            myArray = new T[Capacity];
        }
        public CustomList(int capacity)
        {
            this.capacity = capacity;
            myArray = new T[Capacity];
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
            for (int i = 0; i < count; i++)
            {
                yield return myArray[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add (T value) 
        {
            myArray[count] = value;
            count++;
            MaintainCapacity(MyArray);
        }

        public void Remove(T value) 
        {
            for (int i = 0; i <= count; i++)
            {
                if(myArray[i].Equals(value))
                {
                    for (int j = i; j < (count - 1); j++)  
                    {
                        int nextIndex = (j + 1);
                        myArray[j] = myArray[nextIndex];
                    }
                    myArray[count - 1] = default(T); 
                    count--;
                }
            }            
            MaintainCapacity(MyArray);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int k = 0; k < (count - 1); k++)
            {
                builder.Append(myArray[k]).Append(", ");
            }
            builder.Append(myArray[count - 1]);
            string arrayAsString = builder.ToString();
            return arrayAsString;
        }

        public static CustomList<T> operator + (CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> combinedList = new CustomList<T>();
            for (int i = 0; i < listOne.Count; i++)
            {
                combinedList.Add(listOne[i]);
            }
            for (int j = 0; j < listTwo.Count; j++)
            {
                combinedList.Add(listTwo[j]);
            }
            return combinedList;
        }

        public static CustomList<T> operator - (CustomList<T> listOne, CustomList<T> listTwo)
        {
            for (int i = 0; i < listTwo.Count; i++)
            {
                for (int j = 0; j < listOne.Count; j++)
                {
                    if (listOne[j].Equals(listTwo[i]))
                    {
                        listOne.Remove(listTwo[i]);
                    }
                }
            }
            return listOne;
        }

        public CustomList<T> Zip(CustomList<T> listTwo)
        {
            CustomList<T> zippedList = new CustomList<T>();
            for (int i = 0; i < this.count; i++)
            {
                zippedList.Add(this[i]);
                if (listTwo[i].Equals(default(T)))
                {
                    return zippedList;
                }
                else
                {
                    zippedList.Add(listTwo[i]);
                }
            }
            return zippedList;
        }

        private void MaintainCapacity(T[] list)
        {
            if (count == (capacity * 0.6))
            {
                capacity = (capacity * 2);
                tempArray = new T[capacity];
                for (int i = 0; i <= count; i++)
                {
                    tempArray[i] = list[i];
                }
                MyArray = tempArray;
            }
            if (capacity > 5 && count < (capacity * 0.3))
            {
                capacity = (capacity / 2);
                tempArray = new T[capacity];
                for (int i = 0; i <= count; i++)
                {
                    tempArray[i] = list[i];
                }
                MyArray = tempArray;
            }
        }
    }
}
