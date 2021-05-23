using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class Remove
    {
        [Test]
        public void WhenCalled_ShouldRemoveNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(n => n.Value == 4);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 2);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenTElementPassed_ShouldRemoveFirstNodeContainingElement()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10, 2 });

            sut.Remove(2);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.AreEqual(fourth.Value, 2);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledAndMatchesHead_ShouldRemoveHead()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(n => n.Value == 1);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 2);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledPassingElementAndMatchesHead_ShouldRemoveHead()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(1);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 2);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNode_ShouldRemoveNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(sut.Head.Next);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndIsHead_ShouldRemoveHead()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(sut.Head);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 2);
            Assert.AreEqual(second.Value, 4);
            Assert.AreEqual(third.Value, 10);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndPassedElement_ShouldNodeContainingElement()
        {
            var sut = new LighterList<Person>(new List<Person> 
            {
                new Person(1, "a", "e"),
                new Person(2, "b", "f"),
                new Person(3, "c", "g"),
                new Person(4, "d", "h"),
            });

            sut.Remove(sut.Head.Next.Value);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value.Id, 1);
            Assert.AreEqual(first.Value.Name, "a");
            Assert.AreEqual(second.Value.Id, 3);
            Assert.AreEqual(second.Value.Name, "c");
            Assert.AreEqual(third.Value.Id, 4);
            Assert.AreEqual(third.Value.Name, "d");
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndPassedElementWithNoMatch_ShouldNotRemoveAnything()
        {
            var sut = new LighterList<Person>(new List<Person>
            {
                new Person(1, "a", "e"),
                new Person(2, "b", "f"),
                new Person(3, "c", "g"),
                new Person(4, "d", "h"),
            });

            sut.Remove(new Person(1, "a", "e"));

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(first.Value.Id, 1);
            Assert.AreEqual(first.Value.Name, "a");
            Assert.AreEqual(second.Value.Id, 2);
            Assert.AreEqual(second.Value.Name, "b");
            Assert.AreEqual(third.Value.Id, 3);
            Assert.AreEqual(third.Value.Name, "c");
            Assert.AreEqual(fourth.Value.Id, 4);
            Assert.AreEqual(fourth.Value.Name, "d");
            Assert.IsNull(fourth.Next);
        }
    }
}
