using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework7_1.Tests
{
    [TestClass()]
    public class ListTests
    {
        private List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();
        }

        [TestMethod()]
        public void Add_5_To_2_PositionTest()
        {
            list.AddValue(1, 0);
            list.AddValue(1, 0);
            list.AddValue(5, 2);
            Assert.AreEqual(list.GetValue(2), 5);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_5_ToEmptyListOn_2_PositionExceptionTest()
        {
            list.AddValue(5, 2);
        }

        [TestMethod()]
        public void GetValueByZeroPositionTest()
        {
            list.AddValue(1, 0);
            Assert.AreEqual(1, list.GetValue(0));
        }

        [TestMethod()]
        public void Delete_5_FromListTest()
        {
            list.AddValue(1, 0);
            list.AddValue(1, 0);
            list.AddValue(5, 2);
            list.DeleteElement(2);
            for (int i = 0; i < list.GetLength(); i++)
            {
                Assert.AreEqual(1, list.GetValue(i));
            }
        }

        [TestMethod]
        public void EnumeratorForEmptyListTest()
        {
            foreach (var element in list)
            {

            }
        }

        [TestMethod]
        public void EnumeratorForListOfOneElementTest()
        {
            list.AddValue(1, 0);
            foreach (var element in list)
            {
                Assert.AreEqual(1, element);
            }
        }

        [TestMethod]
        public void EnumeratorForListOf_14_ElementsTest()
        {
            for (int i = 0; i < 14; i++)
            {
                list.AddValue(13 - i, i);
            }

            bool[] chekValue = new bool[14];
            for (int i = 0; i < 14; i++)
            {
                chekValue[i] = false;
            }

            foreach (int element in list)
            {
                chekValue[element] = true;
            }
            for (int i = 0; i < 14; i++)
            {
                Assert.IsTrue(chekValue[i]);
            }
        }
    }
}
