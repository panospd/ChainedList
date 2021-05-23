using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class RemoveTail
    {
        [Test]
        public void WhenCalled_ShouldRemoveLastNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.RemoveTail();

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(4, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledAndEmptyList_ShouldReturn()
        {
            var sut = new ChainedList<int>();

            sut.RemoveTail();

            Assert.IsNull(sut.Head);
        }

        [Test]
        public void WhenCalledListHasOneNode_ListShouldBeEmpty()
        {
            var sut = new ChainedList<int>(new List<int> { 1 });

            sut.RemoveTail();

            Assert.IsTrue(sut.IsEmpty);
        }
    }
}
