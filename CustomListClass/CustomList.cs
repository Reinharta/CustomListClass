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
            //foreach (T value in MyArray)
            //{
            //    if (value.Equals(default(T)))
            //    {
            //        break;
            //    }
            //    yield return value;
            //}

            for (int i = 0; i < count; i++)
            {
                yield return myArray[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add (T value) //consider using temporary array here
        {
            myArray[count] = value;
            count++;
            MaintainCapacity();
        }
        public void Remove(T value)  //consider using temporary array here
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
            //int listOneCount = listOne.Count;
            CustomList<T> combinedList = new CustomList<T>();
            for (int i = 0; i < listOne.Count; i++)
            {
                combinedList.Add(listOne[i]);
                combinedList.Add(listTwo[i]);
            }
            return combinedList;
        }

        public static CustomList<T> operator - (CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> reducedList = new CustomList<T>();

            return reducedList;
        }

        public CustomList<T> Zip(CustomList<T> listTwo)
        {
            CustomList<T> zippedList = new CustomList<T>();

            return zippedList;
        }

        //public T Sort()
        //{

        //}

        private CustomList<T> MaintainCapacity(CustomList<T> list)
        {
            if (count == (capacity * 0.6))
            {
                capacity = (capacity * 2);
                CustomList<T> biggerList = new CustomList<T>(capacity);
                foreach (T value in list)
                {

                }
                return biggerList;

            }
            if (capacity > 5 && count < (capacity * 0.3))
            {
                capacity = (capacity / 2);
                CustomList<T> smallerList = new CustomList<T>(capacity);
                return smallerList;
            }
            else
            {
                return list;
            }
        }



    }
}
