using System;
using System.Collections.Generic;

namespace LighterLinkedList.core
{
    public class LigherList<T>
    {
        private LighterNode<T> _head = null;

        public LigherList()
        {
            _head = null;
        }

        public LigherList(List<T> items)
        {
            var current = _head;
            LighterNode<T> previous = null;

            for (int i = 0; i < items.Count; i++)
            {
                if (current == null)
                {
                    current = new LighterNode<T>(items[i]);
                    _head = current;
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
        public LighterNode<T> Head => _head;

        /// <summary>
        /// True if LighterList<LighterNode<T>> is empty
        /// </summary>
        public bool IsEmpty => _head == null;

        /// <summary>
        /// Finds the last LighterNode<T>.
        /// </summary>
        public LighterNode<T> Tail { 
            get 
            {
                if (_head == null)
                    return null;

                var current = _head;

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
            var current = _head;

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
            var current = _head;

            _head = new LighterNode<T>(value)
            {
                Next = current
            };
        }

        /// <summary>
        /// Removes head LighterNode<T> from LighterList<LighterNode<T>>.        
        /// </summary>
        public void RemoveFirst()
        {
            if (_head == null)
                return;

            _head = _head.Next;
        }

        /// <summary>
        /// Removes first matching LighterNode<T> from LighterList<LighterNode<T>>.        
        /// </summary>
        public void Remove(Func<LighterNode<T>, bool> predicate)
        {
            var target = Find(predicate);
            RemoveNode(target);
        }

        /// <summary>
        /// Removes specified LighterNode<T> from LighterList<LighterNode<T>>.        
        /// </summary>
        public void Remove(LighterNode<T> node)
        {
            var target = FindReferenceOf(node);
            RemoveNode(target);
        }

        /// <summary>
        /// Removes last LighterNode<T> from LighterList<LighterNode<T>>.        
        /// </summary>
        public void RemoveLast()
        {
            RemoveNode(Tail);
        }

        private void RemoveNode(LighterNode<T> target)
        {
            if (target == null)
                return;

            var previous = FindPreviousOf(target);

            if (previous == null)
            {
                RemoveFirst();
                return;
            }

            previous.Next = target.Next;
        }

        /// <summary>
        /// Inserts T element at the end of LighterList<LighterNode<T>>.        
        /// </summary>
        public void Insert(T value)
        {
            if (Head == null)
                _head = new LighterNode<T>(value);
            else
                Tail.Next = new LighterNode<T>(value);
        }

        /// <summary>
        /// Inserts a range pf T elements at the end of LighterList<LighterNode<T>>.        
        /// </summary>
        public void InsertRange(IEnumerable<T> elements)
        {
            foreach(var element in elements)
                Insert(element);
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
        /// Inserts element after specified LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertAfter(T element, LighterNode<T> node)
        {
            var target = FindReferenceOf(node);
            InsertElementAfter(element, target);
        }

        /// <summary>
        /// Inserts IEnumerable<T> elements after specified LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertRangeAfter(IEnumerable<T> elements, LighterNode<T> node)
        {
            var target = FindReferenceOf(node);
            InsertElementsAfter(elements, target);
        }

        /// <summary>
        /// Inserts IEnumerable<T> elements after matching LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertRangeAfter(IEnumerable<T> elements, Func<LighterNode<T>, bool> predicate)
        {
            var target = Find(predicate);
            InsertElementsAfter(elements, target);
        }

        private void InsertElementsAfter(IEnumerable<T> elements, LighterNode<T> target)
        {
            foreach (var element in elements)
            {
                target = InsertElementAfter(element, target);
            }
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

        /// <summary>
        /// Prints the string representation of each node in the list
        /// </summary>
        public IReadOnlyCollection<string> PrintList()
        {
            var printed = new List<string>();

            var current = Head;

            while(current != null)
            {
                printed.Add(current.Value.ToString());
                current = current.Next;
            }

            return printed;
        }

        /// <summary>
        /// Returns a List<T> of all LighterNode<T> nodes
        /// </summary>
        public List<T> ToList()
        {
            var flatList = new List<T>();

            var current = Head;

            while (current != null)
            {
                flatList.Add(current.Value);
                current = current.Next;
            }

            return flatList;
        }

        private void InsertElementBefore(T element, LighterNode<T> target)
        {
            if (target == null)
            {
                Insert(element);
                return;
            }

            var previous = FindPreviousOf(target);

            if(previous == null)
            {
                InsertAtStart(element);
                return;
            }

            InsertElementAfter(element, previous);
        }

        private LighterNode<T> InsertElementAfter(T element, LighterNode<T> target)
        {
            if (target == null)
            {
                Insert(element);
                return Tail;
            }

            var originalNext = target.Next;
            target.Next = new LighterNode<T>(element);
            target.Next.Next = originalNext;

            return target.Next;
        }

        private LighterNode<T> FindReferenceOf(LighterNode<T> node)
        {
            var current = _head;

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
            var current = _head;

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
