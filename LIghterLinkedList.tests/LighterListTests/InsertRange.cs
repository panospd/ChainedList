using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class InsertRange
    {
        [Test]
        public void WhenListIsEmpty_ShouldInsertItems()
        {
            var sut = new LigherList<int>();

            sut.InsertRange(new List<int> { 1, 10, 19 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;

            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 10);
            Assert.AreEqual(third.Value, 19);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalled_ShouldInsertItemsAtEnd()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2 });

            sut.InsertRange(new List<int> { 4, 10 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 2);
            Assert.AreEqual(third.Value, 4);
            Assert.AreEqual(fourth.Value, 10);
            Assert.IsNull(fourth.Next);
        }
    }
}
