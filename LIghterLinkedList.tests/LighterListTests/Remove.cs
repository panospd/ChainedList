using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class Remove
    {
        [Test]
        public void WhenCalled_ShouldRemoveNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(n => n.Value == 4);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 2);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledAndMatchesHead_ShouldRemoveHead()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(n => n.Value == 1);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 2);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNode_ShouldRemoveNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(sut.Head.Next);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndIsHead_ShouldRemoveHead()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(sut.Head);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 2);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }
    }
}
