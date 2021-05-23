using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class RemoveHead
    {
        [Test]
        public void WhenCalled_ShouldRemoveHead()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.RemoveHead();

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(2, first.Value);
            Assert.AreEqual(4, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledForListWithOneNode_ShouldEmptyList()
        {
            var sut = new ChainedList<int>(new List<int> { 1 });

            sut.RemoveHead();

            Assert.IsTrue(sut.IsEmpty);
        }
    }
}
