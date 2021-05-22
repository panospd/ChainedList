using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class PrintList
    {
        [Test]
        public void WhenCalled_ReturnsStringRepresentationOfEachNode()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 3, 4 });

            var result = sut.PrintList().ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result[0], "1");
            Assert.AreEqual(result[1], "2");
            Assert.AreEqual(result[2], "3");
            Assert.AreEqual(result[3], "4");
        }
    }
}
