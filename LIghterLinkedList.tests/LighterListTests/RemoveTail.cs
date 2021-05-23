﻿using LighterLinkedList.core;
using NUnit.Framework;
using System.Collections.Generic;

namespace LIghterLinkedList.tests.LighterListTests
{
    public class RemoveTail
    {
        [Test]
        public void WhenCalled_ShouldRemoveLastNode()
        {
            var sut = new LighterList<int>(new List<int> { 1, 2, 4, 10 });

            sut.RemoveTail();

            var first = sut.Head;
            var second = first.Next;
            var third = second.Next;
            Assert.AreEqual(first.Value, 1);
            Assert.AreEqual(second.Value, 2);
            Assert.AreEqual(third.Value, 4);
            Assert.IsNull(third.Next);
        }

        [Test]
        public void WhenCalledAndEmptyList_ShouldReturn()
        {
            var sut = new LighterList<int>();

            sut.RemoveTail();

            Assert.IsNull(sut.Head);
        }

        [Test]
        public void WhenCalledListHasOneNode_ListShouldBeEmpty()
        {
            var sut = new LighterList<int>(new List<int> { 1 });

            sut.RemoveTail();

            Assert.IsTrue(sut.IsEmpty);
        }
    }
}