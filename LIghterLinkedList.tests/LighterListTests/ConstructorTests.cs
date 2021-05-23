using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class ConstructorTests
    {
        [Test]
        public void WhenCreatingFromList_CreatesNewLighterList()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            var head = sut.Head;
            var second = head.Next;
            var third = second.Next;

            Assert.AreEqual(1, head.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(4, third.Value);
        }
    }
}
