using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class InsertBefore
    {
        [Test]
        public void WhenCalledWithPredicate_ShouldInsertItemBeforeMatchingNode()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });

            sut.InsertBefore(10, node => node.Value == 2);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 10);
            Assert.AreEqual(third.Value, 2);
            Assert.AreEqual(fourth.Value, 4);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithPredicateAndWithNoMatchingNode_ShouldInsertItemAtEnd()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });

            sut.InsertBefore(10, node => node.Value == 8);

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

        [Test]
        public void WhenCalledWithPredicateAndWithEmptyList_ShouldInsertItemAtEnd()
        {
            var sut = new LigherList<int>();

            sut.InsertBefore(10, node => node.Value == 1);

            var first = sut.Head;
            Assert.AreEqual(first.Value, 10);
            Assert.IsNull(first.Next);
        }

        [Test]
        public void WhenCalledWithRefNode_ShouldInsertItemBeforeMatchingNode()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });
            var first = sut.Head;

            sut.InsertBefore(10, first.Next.Next);

            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 2);
            Assert.AreEqual(third.Value, 10);
            Assert.AreEqual(fourth.Value, 4);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndWithNoMatchingNode_ShouldInsertItemAtEnd()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });
            var node = new LighterNode<int>(10);

            sut.InsertBefore(10, node);

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
