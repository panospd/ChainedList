using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests
{
    public class LighterListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreatingFromList_CreatesNewLighterList()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });

            var head = sut.First;
            var second = head.Next;
            var third = second.Next;

            Assert.AreEqual(head.Value, 1);
            Assert.AreEqual(second.Value, 2);
            Assert.AreEqual(third.Value, 4);
        }

        [Test]
        public void Find_When_Called_ReturnsFirstMatch()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Find(a => a.Value == 2);

            Assert.AreEqual(result.Value, 2);
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void Find_WhenCalledWithNoMatch_ReturnsNUll()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Find(a => a.Value == 5);

            Assert.IsNull(result);
        }

        [Test]
        public void Last_WhenUsed_ShouldReturnLastNode()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Last;

            Assert.AreEqual(result.Value, 4);
        }

        [Test]
        public void Last_WhenUsedAndListIsEmpty_ShouldReturnNull()
        {
            var sut = new LigherList<int>();

            var result = sut.Last;

            Assert.IsNull(result);
        }

        [Test]
        public void InsertAtStart_WhenCalled_ShouldInsertItemAtStart()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 4 });
            sut.InsertAtStart(10);

            var first = sut.First;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;

            Assert.AreEqual(first.Value, 10);
            Assert.AreEqual(second.Value, 1);
            Assert.AreEqual(third.Value, 2);
            Assert.AreEqual(fourth.Value, 4);
        }

        [Test]
        public void InsertAtStart_WhenListIsEmpty_ShouldInsertItemAtStart()
        {
            var sut = new LigherList<int>();
            sut.InsertAtStart(10);

            var first = sut.First;

            Assert.AreEqual(first.Value, 10);
            Assert.IsNull(first.Next);
        }
    }
}