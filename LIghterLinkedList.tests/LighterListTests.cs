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
    }
}