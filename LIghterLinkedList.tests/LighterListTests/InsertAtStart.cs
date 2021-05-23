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
            Assert.AreEqual(10, first.Value);
            Assert.AreEqual(1, second.Value);
            Assert.AreEqual(2, third.Value);
            Assert.AreEqual(4, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenListIsEmpty_ShouldInsertItemAtStart()
        {
            var sut = new LighterList<int>();

            sut.InsertAtStart(10);

            Assert.AreEqual(10, sut.Head.Value);
            Assert.IsNull(sut.Head.Next);
        }
    }
}
