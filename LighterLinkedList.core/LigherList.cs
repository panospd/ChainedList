using System;
using System.Collections.Generic;

namespace LighterLinkedList.core
{
    public class LigherList<T>
    {
        private LighterNode<T> Head { get; set; }

        public LigherList()
        {
            Head = null;
        }

        public LigherList(List<T> items)
        {
            var current = Head;
            LighterNode<T> previous = null;

            for (int i = 0; i < items.Count; i++)
            {
                if (current == null)
                {
                    current = new LighterNode<T>(items[i]);
                    Head = current;
                    continue;
                }

                if (current.Value != null)
                {
                    previous = current;
                    current = new LighterNode<T>(items[i]);
                }

                if (previous != null)
                    previous.Next = current;
            }
        }

        /// <summary>
        /// Finds the head LighterNode<T>.
        /// </summary>
        public LighterNode<T> First => Head;

        /// <summary>
        /// Finds the last LighterNode<T>.
        /// </summary>
        public LighterNode<T> Last { 
            get 
            {
                if (Head == null)
                    return null;

                var current = Head;

                while(current.Next != null)
                {
                    current = current.Next;
                }

                return current;
            } 
        }

        /// <summary>
        /// Finds the first element based on predicate If no node found will return null.
        /// <param name="predicate">Predicate that accepts type of T</param>
        /// </summary>
        public LighterNode<T> Find(Func<LighterNode<T>, bool> predicate)
        {
            var current = Head;

            while (current != null)
            {
                if (predicate(current))
                    return current;

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// Inserts element as the head of LighterList.
        /// <param name="value">Item of type T to add to the list</param>
        /// </summary>
        public void InsertAtStart(T value)
        {
            var current = Head;

            Head = new LighterNode<T>(value)
            {
                Next = current
            };
        }

        /// <summary>
        /// Inserts element at the end of LighterList.
        /// <param name="value">Item of type T to add to the list</param>
        /// </summary>
        public void InsertAtEnd(T value)
        {
            if (Last == null)
                Head = new LighterNode<T>(value);
            else
                Last.Next = new LighterNode<T>(value);
        }
    }
}
