using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class Last
    {
        [Test]
        public void WhenUsed_ShouldReturnLastNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Tail;

            Assert.AreEqual(result.Value, 4);
        }

        [Test]
        public void WhenUsedAndListIsEmpty_ShouldReturnNull()
        {
            var sut = new LighterList<int>();

            var result = sut.Tail;

            Assert.IsNull(result);
        }
    }
}
