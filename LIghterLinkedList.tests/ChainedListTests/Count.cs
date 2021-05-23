using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class Count
    {
        [Test]
        public void WhenListIsEmpty_ShouldReturn0()
        {
            var sut = new ChainedList<int>();

            Assert.AreEqual(0, sut.Count);
        }

        [Test]
        public void WhenListContainsNodes_ShouldReturnTotalNumberOfNodes()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 6 });

            Assert.AreEqual(4, sut.Count);
        }

        [Test]
        public void WhenRemoveNode_CountShouldDecrement()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 6 });
            var originalCount = sut.Count;

            sut.Remove(sut.Head);
            var newCount = sut.Count;

            Assert.AreEqual(4, originalCount);
            Assert.AreEqual(3, newCount);
        }
    }
}
