using System;
using CustomListClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomListClassTest
{
    [TestClass]
    public class CustomListTest
    {
        //ADD METHOD
        [TestMethod]
        public void Add_String_Value_Check_Index()
        {
            //ARRANGE
            CustomList<string> list = new CustomList<string>();
            string value = "test";

            //ACT
            list.Add(value);
            string actualResult = list[0];

            //ASSERT
            Assert.AreEqual(actualResult, value);
        }
        
        [TestMethod]
        public void Add_Mult_Int_Values_Check_Index()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>();
            int valueOne = 1;
            int valueTwo = 2;
            int valueThree = 3;

            //ACT
            list.Add(valueOne);
            list.Add(valueTwo);
            list.Add(valueThree);
            int actualResult = list[1];

            //ASSERT
            Assert.AreEqual(actualResult, valueTwo);
        }

        [TestMethod]
        public void Add_Int_To_Prepopulated_Check_Index()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2, 3 };
            int value = 4;

            //ACT
            list.Add(value);
            int actualResult = list[3];

            //ASSERT
            Assert.AreEqual(actualResult, value);
        }

        [TestMethod]
        public void Add_List_As_Value_Check_Index()
        {
            //ARRANGE
            CustomList<CustomList<string>> parentList = new CustomList<CustomList<string>>();
            CustomList<string> internalList = new CustomList<string>() { "foo", "bar" };
            string expectedResult = "bar";

            //ACT
            parentList.Add(internalList);
            string actualResult = parentList[0][1];

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Add_Values_Check_Capacity_Doubled()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2 };
            int valueOne = 3;
            int valueTwo = 4;
            int expectedResult = 10;

            //ACT
            list.Add(valueOne);
            list.Add(valueTwo);
            int actualResult = list.Capacity;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }


    
        //REMOVE METHOD

        [TestMethod]
        public void Remove_Int_Check_Index()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2, 3 };
            int removedValue = 3;
            int expectedResult = default(int);

            //ACT
            list.Remove(removedValue);
            int actualResult = list[2];

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Remove_Int_Check_Count()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2, 3 };
            int removedValue = 3;
            int expectedResult = 2;

            //ACT
            list.Remove(removedValue);
            int actualResult = list.Count;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Remove_Multiple_Int_Check_Count()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2, 3, 4 };
            int removedValueOne = 4;
            int removedValueTwo = 2;
            int expectedResult = 2;

            //ACT
            list.Remove(removedValueOne);
            list.Remove(removedValueTwo);
            int actualResult = list.Count;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Remove_Multiple_Decrease_Capacity()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2, 3 };
            int removedValue = 3;
            int expectedResult = 5;

            //ACT
            list.Remove(removedValue);
            int actualResult = list.Capacity;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }



        //TOSTRING METHOD

        [TestMethod]
        public void Stringify_Check_Index_Value()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2, 3 };

            int expectedResult = 3;     //index based on counting spaces and commas

            //ACT
            string stringResult = list.ToString();
            int actualResult = stringResult.IndexOf("2");

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Stringify_Check_Length()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2, 3 };
            int expectedResult = 7; //this includes spaces and commas, not sure if these are actually counted w/ length

            //ACT
            string stringResult = list.ToString();
            int actualResult = stringResult.Length;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Stringify_Check_String_Output()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2, 3 };
            string expectedResult = "1, 2, 3";

            //ACT
            string actualResult = list.ToString();

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }



        //PLUS OVERLOAD          

        [TestMethod]
        public void Add_Two_Lists_Check_Count()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 2, 3 };
            CustomList<int> listTwo = new CustomList<int> { 4, 5, 6 };
            int expectedResult = 6;

            //ACT
            CustomList<int> newList = listOne + listTwo;
            int actualResult = newList.Count;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Add_Two_Lists_Check_Index_Value()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 2, 3 };
            CustomList<int> listTwo = new CustomList<int> { 4, 5, 6 };
            int expectedResult = 4;

            //ACT
            CustomList<int> newList = listOne + listTwo;
            int actualResult = newList[3];

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Add_Three_Lists_Check_Count()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 2, 3 };
            CustomList<int> listTwo = new CustomList<int> { 4, 5, 6 };
            CustomList<int> listThree = new CustomList<int> { 7, 8 };
            int expectedResult = 8;

            //ACT
            CustomList<int> newList = (listOne + listTwo) + listThree;
            int actualResult = newList.Count;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);

        }



        //MINUS OVERLOAD            

        [TestMethod]
        public void Subtract_Values_Check_Count()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 2, 3, 4, 5, 6, 7 };
            CustomList<int> listTwo = new CustomList<int> { 1, 4, 7, 9 };
            int expectedResult = 4;

            //ACT
            CustomList<int> newList = listOne - listTwo;
            int actualResult = newList.Count;


            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Subtract_Values_Check_Index_Value()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 2, 3, 4, 5 };
            CustomList<int> listTwo = new CustomList<int> { 2, 3 };
            int expectedResult = 4;

            //ACT
            CustomList<int> newList = listOne - listTwo;
            int actualResult = newList[1];

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Subtract_No_Values_Check_Count()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 2, 3 };
            CustomList<int> listTwo = new CustomList<int> { 4, 5, 6 };
            int expectedResult = 3;

            //ACT
            CustomList<int> newList = listOne - listTwo;
            int actualResult = newList.Count;
            
            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }


        //ZIP METHOD

        [TestMethod]
        public void Zip_Lists_Equal_Length_Check_Count()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 3, 5 };
            CustomList<int> listTwo = new CustomList<int> { 2, 4, 6 };
            int expectedResult = 6;

            //ACT
            CustomList<int> zipList = listOne.Zip(listTwo);
            int actualResult = zipList.Count;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Zip_Lists_Equal_Length_Check_Index()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 3, 5 };
            CustomList<int> listTwo = new CustomList<int> { 2, 4, 6 };
            int expectedResult = 4;

            //ACT
            CustomList<int> zipList = listOne.Zip(listTwo);
            int actualResult = zipList[3];

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Zip_Lists_First_Shorter_Check_Count()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 3 };
            CustomList<int> listTwo = new CustomList<int> { 2, 4, 6 };
            int expectedResult = 4;

            //ACT
            CustomList<int> zipList = listOne.Zip(listTwo);
            int actualResult = zipList.Count;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Zip_Lists_Second_Shorter_Check_Count()
        {
            //ARRANGE
            CustomList<int> listOne = new CustomList<int> { 1, 3, 5 };
            CustomList<int> listTwo = new CustomList<int> { 2, 4 };
            int expectedResult = 5;

            //ACT
            CustomList<int> zipList = listOne.Zip(listTwo);
            int actualResult = zipList.Count;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
