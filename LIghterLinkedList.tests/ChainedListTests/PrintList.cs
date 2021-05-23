using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ChainedList.tests.ChainedListTests
{
    public class PrintList
    {
        [Test]
        public void WhenCalled_ReturnsStringRepresentationOfEachNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 3, 4 });

            var result = sut.PrintList().ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual("1", result[0]);
            Assert.AreEqual("2", result[1]);
            Assert.AreEqual("3", result[2]);
            Assert.AreEqual("4", result[3]);
        }

        [Test]
        public void WhenCalledWithObjectNodeValue_ReturnsStringRepresentationOfEachNode()
        {
            var sut = new ChainedList<Person>(new List<Person> 
                { 
                    new Person("Panos", "Anastasiadis"),
                    new Person("John", "Smith")
                });

            var result = sut.PrintList().ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("My name is Panos Anastasiadis", result[0]);
            Assert.AreEqual("My name is John Smith", result[1]);
        }

        [Test]
        public void WhenListIsEmpty_ShouldReturnAnEmptyList()
        {
            var sut = new ChainedList<int>(new List<int>());

            var result = sut.PrintList();

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
    }
}
