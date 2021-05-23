using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class Insert
    {
        [Test]
        public void WhenListIsEmpty_ShouldInsertItem()
        {
            var sut = new ChainedList<int>();

            sut.Insert(10);

            Assert.AreEqual(10, sut.Head.Value);
            Assert.IsNull(sut.Head.Next);
        }

        [Test]
        public void WhenCalled_ShouldInsertItemAtEnd()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.Insert(10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(4, third.Value);
            Assert.AreEqual(10, fourth.Value);
            Assert.IsNull(fourth.Next);
        }
    }
}
