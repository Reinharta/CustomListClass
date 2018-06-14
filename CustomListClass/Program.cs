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
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4, 5 };

            foreach (int value in list)
            {
                Console.WriteLine(value);
            }
            Console.ReadKey();

            Console.WriteLine(list.ToString());
            Console.ReadKey();
            
            
        }
    }
}
