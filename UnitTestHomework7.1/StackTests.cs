using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework7_1.Tests
{
    [TestClass]
    public class StackTests
    {
        private Stack<int> stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack<int>();
        }

        [TestMethod()]
        public void PushZeroToStackTest()
        {
            stack.Push(0);
            Assert.AreEqual(0, stack.Pop());
            Assert.IsTrue(stack.IsStackEmpty());
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromTheEmptyStackShouldTest()
        {
            stack.Pop();
        }

        [TestMethod()]
        public void PushAndPopTestWith_1_And_2()
        {
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }

        [TestMethod()]
        public void CheckIfStackIsEmpty()
        {
            Assert.IsTrue(stack.IsStackEmpty());
        }
    }
}
