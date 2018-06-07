﻿using System;
using CustomListClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomListClassTest
{
    [TestClass]
    public class CustomListTest
    {
        //ADD METHOD
        [TestMethod]
        public void AddStringValueToList()
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
        public void AddMultIntValuesToList()
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
        public void AddIntToExistingList()
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
        public void AddListAsListValue()
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
        public void AddValuesDoubleCapacity()
        {
            //ARRANGE
            CustomList<int> list = new CustomList<int>() { 1, 2 };
            int valueOne = 3;
            int valueTwo = 4;
            int expectedResult = 10;

            //ACT
            list.Add(valueOne);
            list.Add(valueTwo);
            int actualResult = list.capacity;

            //ASSERT
            Assert.AreEqual(expectedResult, actualResult);
        }



        //REMOVE METHOD

    }
}
