using System;
using System.Collections.Generic;
using System.Linq;

namespace LighterLinkedList.core
{
    public class LighterList<T>
    {
        private LighterNode<T> _head = null;

        public LighterList()
        {
            _head = null;
        }

        public LighterList(List<T> items)
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
        /// Finds the first node that matches predicate.
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
        /// Finds the first node that matches predicate.
        /// </summary>
        public LighterNode<T> Find(Func<T, bool> predicate)
        {
            var current = _head;

            while (current != null)
            {
                if (predicate(current.Value))
                    return current;

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// Finds the first node based that contains the specified value.
        /// </summary>
        public LighterNode<T> Find(T value)
        {
            var current = _head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
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
        public void RemoveHead()
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
        /// Removes specified LighterNode<T> node from LighterList<LighterNode<T>>.        
        /// </summary>
        public void Remove(LighterNode<T> node)
        {
            var target = FindReferenceOf(node);
            RemoveNode(target);
        }

        /// <summary>
        /// Removes the first node that contains specified value.        
        /// </summary>
        public void Remove(T value)
        {
            var target = Find(value);
            RemoveNode(target);
        }

        /// <summary>
        /// Removes specified IEnumerable<LighterNode<T>> nodes from LighterList<LighterNode<T>>.        
        /// </summary>
        public void RemoveAll(IEnumerable<LighterNode<T>> nodes)
        {
            foreach (var node in nodes)
                Remove(node);
        }

        /// <summary>
        /// Removes all IEnumerable<LighterNode<T>> nodes from LighterList<LighterNode<T>>.        
        /// </summary>
        public void RemoveAll()
        {
            _head = null;
        }

        /// <summary>
        /// Removes last LighterNode<T> from LighterList<LighterNode<T>>.        
        /// </summary>
        public void RemoveTail()
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
                RemoveHead();
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
        public void InsertAfter(Func<LighterNode<T>, bool> predicate, T element)
        {
            var target= Find(predicate);
            InsertElementAfter(element, target);
        }

        /// <summary>
        /// Inserts element after specified LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertAfter(LighterNode<T> node, T element)
        {
            var target = FindReferenceOf(node);
            InsertElementAfter(element, target);
        }

        /// <summary>
        /// Inserts IEnumerable<T> elements after specified LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertRangeAfter(LighterNode<T> node, IEnumerable<T> elements)
        {
            var target = FindReferenceOf(node);
            InsertElementsAfter(target, elements);
        }

        /// <summary>
        /// Inserts IEnumerable<T> elements after matching LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertRangeAfter(Func<LighterNode<T>, bool> predicate, IEnumerable<T> elements)
        {
            var target = Find(predicate);
            InsertElementsAfter(target, elements);
        }

        /// <summary>
        /// Inserts element before matching LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertBefore(Func<LighterNode<T>, bool> predicate, T element)
        {
            var target = Find(predicate);
            InsertElementBefore(element, target);
        }

        /// <summary>
        /// Inserts T element before specified LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertBefore(LighterNode<T> node, T element)
        {
            var target = FindReferenceOf(node);
            InsertElementBefore(element, target);
        }

        /// <summary>
        /// Inserts IEnumerable<T> elements before specified LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertRangeBefore(LighterNode<T> node, IEnumerable<T> elements)
        {
            var target = FindReferenceOf(node);
            InsertElementsBefore(target, elements);
        }

        /// <summary>
        /// Inserts IEnumerable<T> elements before matching LighterNode<T> in LighterList<LighterNode<T>>. 
        /// If no matching LighterNode<T> found, will insert at the end of LighterList<LighterNode<T>>   
        /// </summary>
        public void InsertRangeBefore(Func<LighterNode<T>, bool> predicate, IEnumerable<T> elements)
        {
            var target = Find(predicate);
            InsertElementsBefore(target, elements);
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

        private void InsertElementsBefore(LighterNode<T> target, IEnumerable<T> elements)
        {
            var elementsList = elements.ToList();

            for (int i = elementsList.Count - 1; i > -1; i--)
            {
                target = InsertElementBefore(elementsList[i], target);
            }
        }

        private void InsertElementsAfter(LighterNode<T> target, IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                target = InsertElementAfter(element, target);
            }
        }

        private LighterNode<T> InsertElementBefore(T element, LighterNode<T> target)
        {
            if (target == null)
            {
                Insert(element);
                return Tail;
            }

            var previous = FindPreviousOf(target);

            if(previous == null)
            {
                InsertAtStart(element);
                return Head;
            }

            return InsertElementAfter(element, previous);
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
