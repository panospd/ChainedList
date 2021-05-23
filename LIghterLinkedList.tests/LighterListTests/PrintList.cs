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
            var sut = new LighterList<int>(new List<int> { 1, 2, 3, 4 });

            var result = sut.PrintList().ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result[0], "1");
            Assert.AreEqual(result[1], "2");
            Assert.AreEqual(result[2], "3");
            Assert.AreEqual(result[3], "4");
        }

        [Test]
        public void WhenCalledWithObjectNodeValue_ReturnsStringRepresentationOfEachNode()
        {
            var sut = new LighterList<Person>(new List<Person> 
                { 
                    new Person("Panos", "Anastasiadis"),
                    new Person("John", "Smith")
                });

            var result = sut.PrintList().ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0], "My name is Panos Anastasiadis");
            Assert.AreEqual(result[1], "My name is John Smith");
        }

        [Test]
        public void WhenListIsEmpty_ShouldReturnAnEmptyList()
        {
            var sut = new LighterList<int>(new List<int>());

            var result = sut.PrintList();

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
    }
}
