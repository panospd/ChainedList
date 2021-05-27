using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class AddRangeBefore
    {
        [Test]
        public void WhenCalled_ShouldInsertItemBeforeSpecifiedNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddRangeBefore(sut.Head.Next, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            var fifth = fourth.Next;
            var sixth = fifth.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.AreEqual(11, third.Value);
            Assert.AreEqual(12, fourth.Value);
            Assert.AreEqual(2, fifth.Value);
            Assert.AreEqual(4, sixth.Value);
            Assert.IsNull(sixth.Next);
        }

        [Test]
        public void WhenListIsEmpty_ShouldInsertItemsToList()
        {
            var sut = new ChainedList<int>();

            sut.AddRangeBefore(sut.Head, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(10, first.Value);
            Assert.AreEqual(11, second.Value);
            Assert.AreEqual(12, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenTargetNodeIsHead_ShouldInsertItemsAtStart()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddRangeBefore(sut.Head, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            var fifth = fourth.Next;
            var sixth = fifth.Next;
            Assert.AreEqual(10, first.Value);
            Assert.AreEqual(11, second.Value);
            Assert.AreEqual(12, third.Value);
            Assert.AreEqual(1, fourth.Value);
            Assert.AreEqual(2, fifth.Value);
            Assert.AreEqual(4, sixth.Value);
            Assert.IsNull(sixth.Next);
        }

        [Test]
        public void WhenCalledWithPredicate_ShouldInsertItemBeforeSpecifiedNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddRangeBefore(n => n.Value == 2, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            var fifth = fourth.Next;
            var sixth = fifth.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(10, second.Value);
            Assert.AreEqual(11, third.Value);
            Assert.AreEqual(12, fourth.Value);
            Assert.AreEqual(2, fifth.Value);
            Assert.AreEqual(4, sixth.Value);
            Assert.IsNull(sixth.Next);
        }

        [Test]
        public void WhenCalledWithPredicateAndListIsEmpty_ShouldInsertItemsToList()
        {
            var sut = new ChainedList<int>();

            sut.AddRangeBefore(n => n == sut.Head, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(10, first.Value);
            Assert.AreEqual(11, second.Value);
            Assert.AreEqual(12, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithPredicateAndTargetNodeIsHead_ShouldInsertItemsAtStart()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            sut.AddRangeBefore(n => n.Value == 1, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            var fifth = fourth.Next;
            var sixth = fifth.Next;
            Assert.AreEqual(10, first.Value);
            Assert.AreEqual(11, second.Value);
            Assert.AreEqual(12, third.Value);
            Assert.AreEqual(1, fourth.Value);
            Assert.AreEqual(2, fifth.Value);
            Assert.AreEqual(4, sixth.Value);
            Assert.IsNull(sixth.Next);
        }
    }
}
