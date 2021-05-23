using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class Reverse
    {
        [Test]
        public void WhenCalled_ReturnsFlatList()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 3, 4 });

            sut.Reverse();

            Assert.AreEqual(sut.Count, 4);
            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(4, first.Value);
            Assert.AreEqual(3, second.Value);
            Assert.AreEqual(2, third.Value);
            Assert.AreEqual(1, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenIsEmptyList_ReturnsEmptyList()
        {
            var sut = new ChainedList<int>();

            sut.Reverse();

            Assert.IsTrue(sut.IsEmpty);
        }

        [Test]
        public void WhenHasOneNode_ReturnsListWithOneNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1 });

            sut.Reverse();

            Assert.AreEqual(1, sut.Head.Value);
            Assert.IsNull(sut.Head.Next);
            Assert.IsFalse(sut.IsEmpty);
        }
    }
}
