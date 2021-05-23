using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class InsertRangeAfter
    {
        [Test]
        public void WhenListIsEmpty_ShouldInsertItems()
        {
            var sut = new LighterList<int>();

            sut.InsertRangeAfter(sut.Head, new List<int> { 1, 10, 19 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 10);
            Assert.AreEqual(third.Value, 19);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenListIsEmptyWithPredicate_ShouldInsertItems()
        {
            var sut = new LighterList<int>();

            sut.InsertRangeAfter(node => node == sut.Head, new List<int> { 1, 10, 19 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 10);
            Assert.AreEqual(third.Value, 19);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalled_ShouldInsertItemsAfterNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2 });

            sut.InsertRangeAfter(sut.Head, new List<int> { 4, 10 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.AreEqual(fourth.Value, 2);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithPredicate_ShouldInsertItemsAfterNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2 });

            sut.InsertRangeAfter(n => n.Value == 1, new List<int> { 4, 10 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.AreEqual(fourth.Value, 2);
            Assert.IsNull(fourth.Next);
        }
    }
}
