using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class InsertAtStart
    {
        [Test]
        public void WhenCalled_ShouldInsertItemAtStart()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            sut.InsertAtStart(10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(first.Value, 10);
            Assert.AreEqual(second.Value, 1);
            Assert.AreEqual(third.Value, 2);
            Assert.AreEqual(fourth.Value, 4);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenListIsEmpty_ShouldInsertItemAtStart()
        {
            var sut = new LighterList<int>();

            sut.InsertAtStart(10);

            Assert.AreEqual(sut.Head.Value, 10);
            Assert.IsNull(sut.Head.Next);
        }
    }
}
