using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainedList.core
{
    public class ChainedList<T>
    {
        private ChainedNode<T> _head = null;

        public ChainedList()
        {
            _head = null;
        }

        public ChainedList(IEnumerable<T> initialValues)
        {
            var current = _head;
            ChainedNode<T> previous = null;

            foreach(var initialValue in initialValues)
            {
                if (current == null)
                {
                    current = new ChainedNode<T>(initialValue);
                    _head = current;
                    continue;
                }

                if (current.Value != null)
                {
                    previous = current;
                    current = new ChainedNode<T>(initialValue);
                }

                if (previous != null)
                    previous.Next = current;
            }
        }

        /// <summary>
        /// Returns the head(first) node.
        /// </summary>
        public ChainedNode<T> Head => _head;

        /// <summary>
        /// Returns true if list is empty
        /// </summary>
        public bool IsEmpty => _head == null;

        /// <summary>
        /// Returns the nodes count.
        /// </summary>
        public int Count
        {
            get
            {
                if (_head == null)
                    return default;

                var current = _head;
                int count = 1;

                while (current.Next != null)
                {
                    current = current.Next;
                    count += 1;
                }

                return count;
            }
        }

        /// <summary>
        /// Returns the tail(last) node.
        /// </summary>
        public ChainedNode<T> Tail { 
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
        /// Returns true if List is not empty.
        /// </summary>
        public bool Any()
        {
            return !IsEmpty;
        }

        /// <summary>
        /// Finds the first node that matches predicate.
        /// </summary>
        public ChainedNode<T> Find(Func<ChainedNode<T>, bool> predicate)
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
        public ChainedNode<T> Find(Func<T, bool> predicate)
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
        /// Finds the first node that contains the specified value.
        /// </summary>
        public ChainedNode<T> Find(T value)
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
        /// Inserts value as the head(first) node.        
        /// </summary>
        public void InsertAtStart(T value)
        {
            var current = _head;

            _head = new ChainedNode<T>(value)
            {
                Next = current
            };
        }

        /// <summary>
        /// Removes head(first) node.        
        /// </summary>
        public void RemoveHead()
        {
            if (_head == null)
                return;

            _head = _head.Next;
        }

        /// <summary>
        /// Removes first matching node based on predicate.        
        /// </summary>
        public void Remove(Func<ChainedNode<T>, bool> predicate)
        {
            var target = Find(predicate);
            RemoveNode(target);
        }

        /// <summary>
        /// Removes specified node.        
        /// </summary>
        public void Remove(ChainedNode<T> node)
        {
            var target = FindReferenceOf(node);
            RemoveNode(target);
        }

        /// <summary>
        /// Removes first node that contains specified value.        
        /// </summary>
        public void Remove(T value)
        {
            var target = Find(value);
            RemoveNode(target);
        }

        /// <summary>
        /// Removes all specified nodes.        
        /// </summary>
        public void RemoveAll(IEnumerable<ChainedNode<T>> nodes)
        {
            foreach (var node in nodes)
                Remove(node);
        }

        /// <summary>
        /// Removes the first matching nodes that countain the specified values.        
        /// </summary>
        public void RemoveAll(IEnumerable<T> values)
        {
            foreach (var value in values)
                Remove(value);
        }

        /// <summary>
        /// Removes all matching nodes based on specified predicate.        
        /// </summary>
        public void RemoveAll(Func<T, bool> predicate)
        {
            var nodesToDelete = FindAll(predicate);

            foreach (var node in nodesToDelete)
                Remove(node);
        }

        /// <summary>
        /// Removes all nodes from list.        
        /// </summary>
        public void RemoveAll()
        {
            _head = null;
        }

        /// <summary>
        /// Removes tail(last) node in the list.        
        /// </summary>
        public void RemoveTail()
        {
            RemoveNode(Tail);
        }

        /// <summary>
        /// Inserts value at the end of list.    
        /// </summary>
        public void Insert(T value)
        {
            if (Head == null)
                _head = new ChainedNode<T>(value);
            else
                Tail.Next = new ChainedNode<T>(value);
        }

        /// <summary>
        /// Inserts values at the end of list and in the order specified.        
        /// </summary>
        public void InsertRange(IEnumerable<T> values)
        {
            foreach(var value in values)
                Insert(value);
        }

        /// <summary>
        /// Inserts value after first matching node based on predicate. 
        /// If no matching node found, will insert at the end of list   
        /// </summary>
        public void InsertAfter(Func<ChainedNode<T>, bool> predicate, T value)
        {
            var target= Find(predicate);
            InsertValueAfter(target, value);
        }

        /// <summary>
        /// Inserts value after specified node. 
        /// If no matching node found, will insert at the end of list.   
        /// </summary>
        public void InsertAfter(ChainedNode<T> node, T value)
        {
            var target = FindReferenceOf(node);
            InsertValueAfter(target, value);
        }

        /// <summary>
        /// Inserts values after specified node. 
        /// If no matching node found, will insert at the end of list.
        /// </summary>
        public void InsertRangeAfter(ChainedNode<T> node, IEnumerable<T> values)
        {
            var target = FindReferenceOf(node);
            InsertValuesAfter(target, values);
        }

        /// <summary>
        /// Inserts values after first matching node based on predicate. 
        /// If no matching matching node found, will insert at the end of list.   
        /// </summary>
        public void InsertRangeAfter(Func<ChainedNode<T>, bool> predicate, IEnumerable<T> values)
        {
            var target = Find(predicate);
            InsertValuesAfter(target, values);
        }

        /// <summary>
        /// Inserts value before first matching node based on predicate. 
        /// If no matching node found, will insert at the end of list.   
        /// </summary>
        public void InsertBefore(Func<ChainedNode<T>, bool> predicate, T value)
        {
            var target = Find(predicate);
            InsertValueBefore(target, value);
        }

        /// <summary>
        /// Inserts value before specified node. 
        /// If no matching node found, will insert at the end of list.   
        /// </summary>
        public void InsertBefore(ChainedNode<T> node, T value)
        {
            var target = FindReferenceOf(node);
            InsertValueBefore(target, value);
        }

        /// <summary>
        /// Inserts values before specified node. 
        /// If no matching node found, will insert at the end of list.   
        /// </summary>
        public void InsertRangeBefore(ChainedNode<T> node, IEnumerable<T> values)
        {
            var target = FindReferenceOf(node);
            InsertValuesBefore(target, values);
        }

        /// <summary>
        /// Inserts values before first matching node based on predicate. 
        /// If no matching node found, will insert at the end of list  
        /// </summary>
        public void InsertRangeBefore(Func<ChainedNode<T>, bool> predicate, IEnumerable<T> values)
        {
            var target = Find(predicate);
            InsertValuesBefore(target, values);
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
        /// Returns a List<T> containing the values from all nodes
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

        /// <summary>
        /// Reverses nodes order in the list
        /// </summary>
        public void Reverse()
        {
            if (Count < 2) return;

            var values = ToList();
            values.Reverse();

            RemoveAll();

            InsertRange(values);
        }

        private void RemoveNode(ChainedNode<T> target)
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

        private void InsertValuesBefore(ChainedNode<T> target, IEnumerable<T> values)
        {
            var valuesList = values.ToList();

            for (int i = valuesList.Count - 1; i > -1; i--)
            {
                target = InsertValueBefore(target, valuesList[i]);
            }
        }

        private void InsertValuesAfter(ChainedNode<T> target, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                target = InsertValueAfter(target, value);
            }
        }

        private ChainedNode<T> InsertValueBefore(ChainedNode<T> target, T value)
        {
            if (target == null)
            {
                Insert(value);
                return Tail;
            }

            var previous = FindPreviousOf(target);

            if(previous == null)
            {
                InsertAtStart(value);
                return Head;
            }

            return InsertValueAfter(previous, value);
        }

        private ChainedNode<T> InsertValueAfter(ChainedNode<T> target, T value)
        {
            if (target == null)
            {
                Insert(value);
                return Tail;
            }

            var originalNext = target.Next;
            target.Next = new ChainedNode<T>(value);
            target.Next.Next = originalNext;

            return target.Next;
        }

        private IEnumerable<ChainedNode<T>> FindAll(Func<T, bool> predicate)
        {
            var results = new List<ChainedNode<T>>();
            var current = _head;

            while (current != null)
            {
                if (predicate(current.Value))
                    results.Add(current);

                current = current.Next;
            }

            return results;
        }

        private ChainedNode<T> FindReferenceOf(ChainedNode<T> node)
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

        private ChainedNode<T> FindPreviousOf(ChainedNode<T> node)
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
