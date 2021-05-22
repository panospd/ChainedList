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
    }
}