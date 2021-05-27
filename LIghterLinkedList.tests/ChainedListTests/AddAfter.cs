using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class AddAfter
    {
        [Test]
        public void WhenCalledWithPredicate_ShouldInsertItemAfterMatchingNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddAfter(node => node.Value == 1, 10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.AreEqual(2, third.Value);
            Assert.AreEqual(4, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithPredicateAndNoMatchingNode_ShouldInsertItemAtEnd()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddAfter(node => node.Value == 8, 10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(4, third.Value);
            Assert.AreEqual(10, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithPredicateAndEmptyList_ShouldInsertItemAtEnd()
        {
            var sut = new ChainedList<int>();

            sut.AddAfter(node => node.Value == 1, 10);

            Assert.AreEqual(10, sut.Head.Value);
            Assert.IsNull(sut.Head.Next);
        }

        [Test]
        public void WhenCalledWithRefNode_ShouldInsertItemAfterMatchingNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });
            var first = sut.Head;

            sut.AddAfter(first.Next, 10);

            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.AreEqual(4, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndNoMatchingNode_ShouldInsertItemAtEnd()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });
            var node = new ChainedNode<int>(2);

            sut.AddAfter(node, 10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(4, third.Value);
            Assert.AreEqual(10, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledWithTailNode_ShouldInsertItemAtEnd()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddAfter(sut.Tail, 10);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(4, third.Value);
            Assert.AreEqual(10, fourth.Value);
            Assert.IsNull(fourth.Next);
        }
    }
}
