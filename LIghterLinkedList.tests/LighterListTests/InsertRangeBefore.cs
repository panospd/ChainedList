using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class InsertRangeBefore
    {
        [Test]
        public void WhenCalled_ShouldInsertItemBeforeSpecifiedNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            sut.InsertRangeBefore(sut.Head.Next, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            var fifth = fourth.Next;
            var sixth = fifth.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 10);
            Assert.AreEqual(third.Value, 11);
            Assert.AreEqual(fourth.Value, 12);
            Assert.AreEqual(fifth.Value, 2);
            Assert.AreEqual(sixth.Value, 4);
            Assert.IsNull(sixth.Next);
        }

        [Test]
        public void WhenListIsEmpty_ShouldInsertItemsToList()
        {
            var sut = new LighterList<int>();

            sut.InsertRangeBefore(sut.Head, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 10);
            Assert.AreEqual(second.Value, 11);
            Assert.AreEqual(third.Value, 12);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenTargetNodeIsHead_ShouldInsertItemsAtStart()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            sut.InsertRangeBefore(sut.Head, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            var fifth = fourth.Next;
            var sixth = fifth.Next;
            Assert.AreEqual(first.Value, 10);
            Assert.AreEqual(second.Value, 11);
            Assert.AreEqual(third.Value, 12);
            Assert.AreEqual(fourth.Value, 1);
            Assert.AreEqual(fifth.Value, 2);
            Assert.AreEqual(sixth.Value, 4);
            Assert.IsNull(sixth.Next);
        }

        [Test]
        public void WhenCalledWithPredicate_ShouldInsertItemBeforeSpecifiedNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            sut.InsertRangeBefore(n => n.Value == 2, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            var fifth = fourth.Next;
            var sixth = fifth.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 10);
            Assert.AreEqual(third.Value, 11);
            Assert.AreEqual(fourth.Value, 12);
            Assert.AreEqual(fifth.Value, 2);
            Assert.AreEqual(sixth.Value, 4);
            Assert.IsNull(sixth.Next);
        }

        [Test]
        public void WhenCalledWithPredicateAndListIsEmpty_ShouldInsertItemsToList()
        {
            var sut = new LighterList<int>();

            sut.InsertRangeBefore(n => n == sut.Head, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 10);
            Assert.AreEqual(second.Value, 11);
            Assert.AreEqual(third.Value, 12);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithPredicateAndTargetNodeIsHead_ShouldInsertItemsAtStart()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            sut.InsertRangeBefore(n => n.Value == 1, new List<int> { 10, 11, 12 });

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            var fifth = fourth.Next;
            var sixth = fifth.Next;
            Assert.AreEqual(first.Value, 10);
            Assert.AreEqual(second.Value, 11);
            Assert.AreEqual(third.Value, 12);
            Assert.AreEqual(fourth.Value, 1);
            Assert.AreEqual(fifth.Value, 2);
            Assert.AreEqual(sixth.Value, 4);
            Assert.IsNull(sixth.Next);
        }
    }
}
