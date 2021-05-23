using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class RemoveHead
    {
        [Test]
        public void WhenCalled_ShouldRemoveHead()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.RemoveHead();

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 2);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledForListWithOneNode_ShouldEmptyList()
        {
            var sut = new LighterList<int>(new List<int> { 1 });

            sut.RemoveHead();

            Assert.IsTrue(sut.IsEmpty);
        }
    }
}
