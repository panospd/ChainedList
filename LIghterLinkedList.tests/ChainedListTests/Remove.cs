using ChainedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainedList.tests.ChainedListTests
{
    public class Remove
    {
        [Test]
        public void WhenCalled_ShouldRemoveNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(n => n.Value == 4);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(2, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenTElementPassed_ShouldRemoveFirstNodeContainingElement()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10, 2 });

            sut.Remove(2);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            var fourth = third.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(4, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.AreEqual(2, fourth.Value);
            Assert.IsNull(fourth.Next);
        }

        [Test]
        public void WhenCalledAndMatchesHead_ShouldRemoveHead()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(n => n.Value == 1);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(2, first.Value);
            Assert.AreEqual(4, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledPassingElementAndMatchesHead_ShouldRemoveHead()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(1);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(2, first.Value);
            Assert.AreEqual(4, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNode_ShouldRemoveNode()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(sut.Head.Next);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(1, first.Value);
            Assert.AreEqual(4, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndIsHead_ShouldRemoveHead()
        {
            var sut = new ChainedList<int>(new List<int> { 1, 2, 4, 10 });

            sut.Remove(sut.Head);

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(2, first.Value);
            Assert.AreEqual(4, second.Value);
            Assert.AreEqual(10, third.Value);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndPassedElement_ShouldNodeContainingElement()
        {
            var sut = new ChainedList<Person>(new List<Person> 
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
            Assert.AreEqual(1, first.Value.Id);
            Assert.AreEqual("a", first.Value.Name);
            Assert.AreEqual(3, second.Value.Id);
            Assert.AreEqual("c", second.Value.Name);
            Assert.AreEqual(4, third.Value.Id);
            Assert.AreEqual("d", third.Value.Name);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledWithRefNodeAndPassedElementWithNoMatch_ShouldNotRemoveAnything()
        {
            var sut = new ChainedList<Person>(new List<Person>
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
            Assert.AreEqual(1, first.Value.Id);
            Assert.AreEqual("a", first.Value.Name);
            Assert.AreEqual(2, second.Value.Id);
            Assert.AreEqual("b", second.Value.Name);
            Assert.AreEqual(3, third.Value.Id);
            Assert.AreEqual("c", third.Value.Name);
            Assert.AreEqual(4, fourth.Value.Id);
            Assert.AreEqual("d", fourth.Value.Name);
            Assert.IsNull(fourth.Next);
        }
    }
}
