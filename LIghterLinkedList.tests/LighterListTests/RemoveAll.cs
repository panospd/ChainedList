using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class RemoveAll
    {
        [Test]
        public void WhenCalledWithSpecificNodes_ShouldRemoveNodes()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.RemoveAll(new List<LighterNode<int>> { sut.Head, sut.Head.Next });

            var first = sut.Head;
            var second = first.Next;
            Assert.AreEqual(first.Value, 4);
            Assert.AreEqual(second.Value, 10);
            Assert.IsNull(second.Next);
        }

        [Test]
        public void WhenCalledWithSpecificNodesAndListEmpty_ShouldRemoveNodes()
        {
            var sut = new LighterList<int>();

            sut.RemoveAll(new List<LighterNode<int>> { sut.Head });

            Assert.IsTrue(sut.IsEmpty);
        }

        [Test]
        public void WhenCalledWithNoNodes_ShouldRemoveAllNodes()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.RemoveAll();

            Assert.IsTrue(sut.IsEmpty);
        }
    }
}
