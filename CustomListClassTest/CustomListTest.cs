using System;
using CustomListClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomListClassTest
{
    [TestClass]
    public class CustomListTest
    {
        [TestMethod]
        public void Add_String_AddValueToList()
        {
            //ARRANGE
            CustomList<string> list = new CustomList<string>();
            string value = "test";

            //ACT
            list.Add(value);

            //ASSERT
            
        }

    }
}
