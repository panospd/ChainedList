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
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            sut.InsertAfter(node => node.Value == 1, 10);

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
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            sut.InsertAfter(node => node.Value == 8, 10);

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
            var sut = new LighterList<int>();

            sut.InsertAfter(node => node.Value == 1, 10);

            Assert.AreEqual(sut.Head.Value, 10);
            Assert.IsNull(sut.Head.Next);
        }

        [Test]
        public void WhenCalledWithRefNode_ShouldInsertItemAfterMatchingNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });
            var first = sut.Head;

            sut.InsertAfter(first.Next, 10);

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
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });
            var node = new LighterNode<int>(2);

            sut.InsertAfter(node, 10);

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
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            sut.InsertAfter(sut.Tail, 10);

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
