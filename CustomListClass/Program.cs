using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListClass
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> listOne = new CustomList<int>() { 1, 2, 3, 4, 5 };
            CustomList<int> listTwo = new CustomList<int>() { 1, 3, 4 };

            foreach (int value in listOne)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
            foreach (int value in listTwo)
            {
                Console.WriteLine(value);
            }
            Console.ReadKey();
            listOne = listOne - listTwo;
            foreach(int value in listOne)
            {
                Console.WriteLine(value);
            }


            Console.ReadKey();
            
            
        }
    }
}
