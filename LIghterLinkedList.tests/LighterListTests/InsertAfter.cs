using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class InsertAfter
    {
        [Test]
        public void WhenCalledWithPredicate_ShouldInsertItemAfterMatchingNode()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });

            sut.InsertAfter(10, node => node.Value == 1);

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
        public void WhenCalledWithPredicateAndNoMatchingNode_ShouldInsertItemAtEnd()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });

            sut.InsertAfter(10, node => node.Value == 8);

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
        public void WhenCalledWithPredicateAndEmptyList_ShouldInsertItemAtEnd()
        {
            var sut = new LigherList<int>();

            sut.InsertAfter(10, node => node.Value == 1);

            Assert.AreEqual(sut.Head.Value, 10);
            Assert.IsNull(sut.Head.Next);
        }

        [Test]
        public void WhenCalledWithRefNode_ShouldInsertItemAfterMatchingNode()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });
            var first = sut.Head;

            sut.InsertAfter(10, first.Next);

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
        public void WhenCalledWithRefNodeAndNoMatchingNode_ShouldInsertItemAtEnd()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });
            var node = new LighterNode<int>(2);

            sut.InsertAfter(10, node);

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
        public void WhenCalledWithTailNode_ShouldInsertItemAtEnd()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });

            sut.InsertAfter(10, sut.Tail);

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
