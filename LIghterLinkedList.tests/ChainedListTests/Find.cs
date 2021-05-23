using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public partial class Find
    {
        [Test]
        public void WhenCalled_ReturnsFirstMatch()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Find(a => a.Value == 2);

            Assert.AreEqual(2, result.Value);
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithNoMatch_ReturnsNUll()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Find(a => a.Value == 5);

            Assert.IsNull(result);
        }

        [Test]
        public void WhenCalledWithTElement_ReturnsFirstMatch()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Find(2);

            Assert.AreEqual(2, result.Value);
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithObjectTElement_ReturnsFirstMatch()
        {
            var sut = new ChainedList<Person>(new List<Person> 
            {
                new Person(1, "John", "Smith"),
                new Person(2, "Maria", "db"),
                new Person(3, "Docker", "Container"),
                new Person(4, "Ci", "Cd")
            });

            var result = sut.Find(sut.Head.Next.Value);

            Assert.AreEqual(2, result.Value.Id);
            Assert.AreEqual("Maria", result.Value.Name);
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithObjectTElementAndPredicate_ReturnsFirstMatch()
        {
            var sut = new ChainedList<Person>(new List<Person>
            {
                new Person(1, "John", "Smith"),
                new Person(2, "Maria", "db"),
                new Person(3, "Docker", "Container"),
                new Person(4, "Ci", "Cd")
            });

            var result = sut.Find(v => v.Id == 3);

            Assert.AreEqual(3, result.Value.Id);
            Assert.AreEqual("Docker", result.Value.Name);
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithObjectTElementAndPredicateAndNoMatch_ReturnsNull()
        {
            var sut = new ChainedList<Person>(new List<Person>
            {
                new Person(1, "John", "Smith"),
                new Person(2, "Maria", "db"),
                new Person(3, "Docker", "Container"),
                new Person(4, "Ci", "Cd")
            });

            var result = sut.Find(v => v.Id == 5);

            Assert.IsNull(result);
        }

        [Test]
        public void WhenCalledWithObjectTElementWithOverrideEquals_ReturnsFirstMatch()
        {
            var sut = new ChainedList<StrongPerson>(new List<StrongPerson>
            {
                new StrongPerson(1, "John", "Smith"),
                new StrongPerson(2, "Maria", "db"),
                new StrongPerson(3, "Docker", "Container"),
                new StrongPerson(4, "Ci", "Cd")
            });

            var result = sut.Find(sut.Head.Next.Value);

            Assert.AreEqual(2, result.Value.Id);
            Assert.AreEqual("Maria", result.Value.Name);
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithObjectTElementAndNoMatchFound_ReturnsNull()
        {
            var sut = new ChainedList<Person>(new List<Person>
            {
                new Person(1, "John", "Smith"),
                new Person(2, "Maria", "db"),
                new Person(3, "Docker", "Container"),
                new Person(4, "Ci", "Cd")
            });

            var result = sut.Find(new Person(5, "a", "b"));

            Assert.IsNull(result);
        }
    }
}
