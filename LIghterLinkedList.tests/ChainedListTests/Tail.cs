using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class Tail
    {
        [Test]
        public void WhenUsed_ShouldReturnLastNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Tail;

            Assert.AreEqual(4, result.Value);
        }

        [Test]
        public void WhenUsedAndListIsEmpty_ShouldReturnNull()
        {
            var sut = new ChainedList<int>();

            var result = sut.Tail;

            Assert.IsNull(result);
        }
    }
}
