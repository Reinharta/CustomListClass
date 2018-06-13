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
            list.Remove(3);
            //foreach in list (Console.WriteLine()) 
            
        }
    }
}
