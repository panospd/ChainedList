using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class Head
    {
        [Test]
        public void WhenListIsEmpty_ShouldReturnNull()
        {
            var sut = new ChainedList<int>();

            Assert.IsNull(sut.Head);
            Assert.IsTrue(sut.IsEmpty);
            Assert.IsFalse(sut.Any());
        }

        [Test]
        public void WhenListNotEmpty_ShouldReturnFirstNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            Assert.AreEqual(1, sut.Head.Value);
        }
    }
}
