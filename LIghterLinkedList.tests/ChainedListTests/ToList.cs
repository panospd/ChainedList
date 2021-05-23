using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class ToList
    {
        [Test]
        public void WhenCalled_ReturnsFlatList()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 3, 4 });

            var result = sut.ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
            Assert.AreEqual(4, result[3]);
        }

        [Test]
        public void WhenCalledWithObjectNodeValue_ReturnsFlatList()
        {
            var sut = new ChainedList<Person>(new List<Person>
                {
                    new Person("Panos", "Anastasiadis"),
                    new Person("John", "Smith")
                });

            var result = sut.ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Panos", result[0].Name);
            Assert.AreEqual("Anastasiadis", result[0].Surname);
            Assert.AreEqual("John", result[1].Name);
            Assert.AreEqual("Smith", result[1].Surname);
        }

        [Test]
        public void WhenListIsEmpty_ShouldReturnAnEmptyList()
        {
            var sut = new ChainedList<int>(new List<int>());

            var result = sut.ToList();

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
    }
}
