using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class Insert
    {
        [Test]
        public void WhenListIsEmpty_ShouldInsertItem()
        {
            var sut = new LighterList<int>();

            sut.Insert(10);

            Assert.AreEqual(sut.Head.Value, 10);
            Assert.IsNull(sut.Head.Next);
        }

        [Test]
        public void WhenCalled_ShouldInsertItemAtEnd()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            sut.Insert(10);

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
