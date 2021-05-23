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
            var sut = new LigherList<int>();

            sut.InsertRangeAfter(new List<int> { 1, 10, 19 }, sut.Head);

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
            var sut = new LigherList<int>();

            sut.InsertRangeAfter(new List<int> { 1, 10, 19 }, node => object.ReferenceEquals(node, sut.Head));

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
            var sut = new LigherList<int>(new List<int> { 1, 2 });

            sut.InsertRangeAfter(new List<int> { 4, 10 }, sut.Head);

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
            var sut = new LigherList<int>(new List<int> { 1, 2 });

            sut.InsertRangeAfter(new List<int> { 4, 10 }, n => n.Value == 1);

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
