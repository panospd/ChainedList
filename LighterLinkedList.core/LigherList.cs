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
        /// Inserts element as the head of LighterList<LighterNode<T>>.        
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
        /// Inserts element at the end of LighterList<LighterNode<T>>.        
        /// </summary>
        public void InsertAtEnd(T value)
        {
            if (Last == null)
                Head = new LighterNode<T>(value);
            else
                Last.Next = new LighterNode<T>(value);
        }


        /// <summary>
        /// Inserts element after matching LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertAfter(T element, Func<LighterNode<T>, bool> predicate)
        {
            var node = Find(predicate);

            if (node == null)
            {
                InsertAtEnd(element);
                return;
            }

            var originalNext = node.Next;
            node.Next = new LighterNode<T>(element);
            node.Next.Next = originalNext;
        }

        /// <summary>
        /// Inserts element before matching LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertBefore(T element, Func<LighterNode<T>, bool> predicate)
        {
            var node = Find(predicate);

            if (node == null)
            {
                InsertAtEnd(element);
                return;
            }

            var previous = FindPreviousOf(node);

            var originalNext = previous.Next;
            previous.Next = new LighterNode<T>(element);
            previous.Next.Next = originalNext;
        }

        private LighterNode<T> FindPreviousOf(LighterNode<T> node)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Next == node)
                    return current;
            }

            return null;
        }
    }
}
