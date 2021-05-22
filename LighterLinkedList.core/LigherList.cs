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
            var target= Find(predicate);
            InsertElementAfter(element, target);
        }

        /// <summary>
        /// Inserts element after matching LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertAfter(T element, LighterNode<T> node)
        {
            var target = FindReferenceOf(node);
            InsertElementAfter(element, target);
        }

        /// <summary>
        /// Inserts element before matching LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertBefore(T element, Func<LighterNode<T>, bool> predicate)
        {
            var target = Find(predicate);
            InsertElementBefore(element, target);
        }

        /// <summary>
        /// Inserts element before specified LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertBefore(T element, LighterNode<T> node)
        {
            var target = FindReferenceOf(node);
            InsertElementBefore(element, target);
        }

        private void InsertElementBefore(T element, LighterNode<T> target)
        {
            if (target == null)
            {
                InsertAtEnd(element);
                return;
            }

            var previous = FindPreviousOf(target);
            InsertElementAfter(element, previous);
        }

        private void InsertElementAfter(T element, LighterNode<T> target)
        {
            if (target == null)
            {
                InsertAtEnd(element);
                return;
            }

            var originalNext = target.Next;
            target.Next = new LighterNode<T>(element);
            target.Next.Next = originalNext;
        }

        private LighterNode<T> FindReferenceOf(LighterNode<T> node)
        {
            var current = Head;

            while(current != null)
            {
                if (ReferenceEquals(current, node))
                    return current;

                current = current.Next;
            }

            return null;
        }

        private LighterNode<T> FindPreviousOf(LighterNode<T> node)
        {
            var current = Head;

            while (current != null)
            {
                if (ReferenceEquals(current.Next, node))
                    return current;

                current = current.Next;
            }

            return null;
        }
    }
}
