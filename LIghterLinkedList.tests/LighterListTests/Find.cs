using LighterLinkedList.core;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class Find
    {
        [Test]
        public void WhenCalled_ReturnsFirstMatch()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Find(a => a.Value == 2);

            Assert.AreEqual(result.Value, 2);
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithNoMatch_ReturnsNUll()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Find(a => a.Value == 5);

            Assert.IsNull(result);
        }

        [Test]
        public void WhenCalledWithTElement_ReturnsFirstMatch()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4 });

            var result = sut.Find(2);

            Assert.AreEqual(result.Value, 2);
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithObjectTElement_ReturnsFirstMatch()
        {
            var sut = new LighterList<Person>(new List<Person> 
            {
                new Person(1, "John", "Smith"),
                new Person(2, "Maria", "db"),
                new Person(3, "Docker", "Container"),
                new Person(4, "Ci", "Cd")
            });

            var result = sut.Find(sut.Head.Next.Value);

            Assert.AreEqual(result.Value.Id, 2);
            Assert.AreEqual(result.Value.Name, "Maria");
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithObjectTElementAndPredicate_ReturnsFirstMatch()
        {
            var sut = new LighterList<Person>(new List<Person>
            {
                new Person(1, "John", "Smith"),
                new Person(2, "Maria", "db"),
                new Person(3, "Docker", "Container"),
                new Person(4, "Ci", "Cd")
            });

            var result = sut.Find(v => v.Id == 3);

            Assert.AreEqual(result.Value.Id, 3);
            Assert.AreEqual(result.Value.Name, "Docker");
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithObjectTElementAndPredicateAndNoMatch_ReturnsNull()
        {
            var sut = new LighterList<Person>(new List<Person>
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
            var sut = new LighterList<StrongPerson>(new List<StrongPerson>
            {
                new StrongPerson(1, "John", "Smith"),
                new StrongPerson(2, "Maria", "db"),
                new StrongPerson(3, "Docker", "Container"),
                new StrongPerson(4, "Ci", "Cd")
            });

            var result = sut.Find(sut.Head.Next.Value);

            Assert.AreEqual(result.Value.Id, 2);
            Assert.AreEqual(result.Value.Name, "Maria");
            Assert.IsNotNull(result.Next);
        }

        [Test]
        public void WhenCalledWithObjectTElementAndNoMatchFound_ReturnsNull()
        {
            var sut = new LighterList<Person>(new List<Person>
            {
                new Person(1, "John", "Smith"),
                new Person(2, "Maria", "db"),
                new Person(3, "Docker", "Container"),
                new Person(4, "Ci", "Cd")
            });

            var result = sut.Find(new Person(5, "a", "b"));

            Assert.IsNull(result);
        }

        public class StrongPerson : Person
        {
            public StrongPerson(int id, string name, string surname)
                :base(id, name, surname)
            {
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as StrongPerson);
            }

            private bool Equals(StrongPerson other)
            {
                return other != null && Id == other.Id;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Id, Name, Surname);
            }
        }
    }
}
