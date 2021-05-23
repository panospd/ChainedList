using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class InsertRangeAfter
    {
        [Test]
        public void WhenListIsEmpty_ShouldInsertItems()
        {
            var sut = new ChainedList<int>();

            sut.InsertRangeAfter(sut.Head, new List<int> { 1, 10, 19 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.AreEqual(19, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenListIsEmptyWithPredicate_ShouldInsertItems()
        {
            var sut = new ChainedList<int>();

            sut.InsertRangeAfter(node => node == sut.Head, new List<int> { 1, 10, 19 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.AreEqual(19, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalled_ShouldInsertItemsAfterNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2 });

            sut.InsertRangeAfter(sut.Head, new List<int> { 4, 10 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(4, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.AreEqual(2, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithPredicate_ShouldInsertItemsAfterNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2 });

            sut.InsertRangeAfter(n => n.Value == 1, new List<int> { 4, 10 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(4, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.AreEqual(2, fourth.Value);
            Assert.IsNull(fourth.Next);
        }
    }
}
