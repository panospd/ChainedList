using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class ToList
    {
        [Test]
        public void WhenCalled_ReturnsFlatList()
        {
            var sut = new LigherList<int>(new List<int> { 1, 2, 3, 4 });

            var result = sut.ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(result.Count, 4);
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
            Assert.AreEqual(result[2], 3);
            Assert.AreEqual(result[3], 4);
        }

        [Test]
        public void WhenCalledWithObjectNodeValue_ReturnsFlatList()
        {
            var sut = new LigherList<Person>(new List<Person>
                {
                    new Person("Panos", "Anastasiadis"),
                    new Person("John", "Smith")
                });

            var result = sut.ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Name, "Panos");
            Assert.AreEqual(result[0].Surname, "Anastasiadis");
            Assert.AreEqual(result[1].Name, "John");
            Assert.AreEqual(result[1].Surname, "Smith");
        }

        [Test]
        public void WhenListIsEmpty_ShouldReturnAnEmptyList()
        {
            var sut = new LigherList<int>(new List<int>());

            var result = sut.ToList();

            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
    }
}
