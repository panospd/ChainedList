using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class IsEmptyAndAny
    {
        [Test]
        public void WhenListEsEmpty_ShouldReturnTrue()
        {
            var sut = new LighterList<int>();

            Assert.IsTrue(sut.IsEmpty);
            Assert.IsFalse(sut.Any());
        }

        [Test]
        public void WhenRemovesOnlyNOde_ShouldReturnTrue()
        {
            var sut = new LighterList<int>(new List<int> { 1 });

            Assert.IsFalse(sut.IsEmpty);
            Assert.IsTrue(sut.Any());

            sut.RemoveHead();

            Assert.IsTrue(sut.IsEmpty);
            Assert.IsFalse(sut.Any());
        }

        [Test]
        public void WhenListNotEmpty_ShouldReturnFalse()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2 });

            Assert.IsFalse(sut.IsEmpty);
            Assert.IsTrue(sut.Any());

            sut.RemoveHead();

            Assert.IsFalse(sut.IsEmpty);
            Assert.IsTrue(sut.Any());
        }
    }
}
