using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainedList.core
{
    public class ChainedList<T> : ICollection<T>, IEnumerable<T>
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

        public bool IsReadOnly => false;

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
        /// Finds the first node that contains the specified value.
        /// </summary>
        public ChainedNode<T> NodeOf(T value)
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
        public void AddAtStart(T value)
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
            Remove(target);
        }

        /// <summary>
        /// Removes specified node.        
        /// </summary>
        public bool Remove(ChainedNode<T> node)
        {
            var target = FindReferenceOf(node);
            return RemoveNode(target);
        }

        public bool Remove(T item)
        {
            var target = NodeOf(item);
            return Remove(target);
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
            var nodesToDelete = this.Where(predicate);

            foreach (var node in nodesToDelete)
                Remove(node);
        }

        /// <summary>
        /// Removes tail(last) node in the list.        
        /// </summary>
        public void RemoveTail()
        {
            RemoveNode(Tail);
        }

        /// <summary>
        /// Inserts values at the end of list and in the order specified.        
        /// </summary>
        public void AddRange(IEnumerable<T> values)
        {
            foreach(var value in values)
                Add(value);
        }

        /// <summary>
        /// Inserts value after first matching node based on predicate. 
        /// If no matching node found, will insert at the end of list   
        /// </summary>
        public void AddAfter(Func<ChainedNode<T>, bool> predicate, T value)
        {
            var target= Find(predicate);
            InsertValueAfter(target, value);
        }

        /// <summary>
        /// Inserts value after specified node. 
        /// If no matching node found, will insert at the end of list.   
        /// </summary>
        public void AddAfter(ChainedNode<T> node, T value)
        {
            var target = FindReferenceOf(node);
            InsertValueAfter(target, value);
        }

        /// <summary>
        /// Inserts values after specified node. 
        /// If no matching node found, will insert at the end of list.
        /// </summary>
        public void AddRangeAfter(ChainedNode<T> node, IEnumerable<T> values)
        {
            var target = FindReferenceOf(node);
            InsertValuesAfter(target, values);
        }

        /// <summary>
        /// Inserts values after first matching node based on predicate. 
        /// If no matching matching node found, will insert at the end of list.   
        /// </summary>
        public void AddRangeAfter(Func<ChainedNode<T>, bool> predicate, IEnumerable<T> values)
        {
            var target = Find(predicate);
            InsertValuesAfter(target, values);
        }

        /// <summary>
        /// Inserts value before first matching node based on predicate. 
        /// If no matching node found, will insert at the end of list.   
        /// </summary>
        public void AddBefore(Func<ChainedNode<T>, bool> predicate, T value)
        {
            var target = Find(predicate);
            InsertValueBefore(target, value);
        }

        /// <summary>
        /// Inserts value before specified node. 
        /// If no matching node found, will insert at the end of list.   
        /// </summary>
        public void AddBefore(ChainedNode<T> node, T value)
        {
            var target = FindReferenceOf(node);
            InsertValueBefore(target, value);
        }

        /// <summary>
        /// Inserts values before specified node. 
        /// If no matching node found, will insert at the end of list.   
        /// </summary>
        public void AddRangeBefore(ChainedNode<T> node, IEnumerable<T> values)
        {
            var target = FindReferenceOf(node);
            InsertValuesBefore(target, values);
        }

        /// <summary>
        /// Inserts values before first matching node based on predicate. 
        /// If no matching node found, will insert at the end of list  
        /// </summary>
        public void AddRangeBefore(Func<ChainedNode<T>, bool> predicate, IEnumerable<T> values)
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
        /// Reverses nodes order in the list
        /// </summary>
        public void Reverse()
        {
            if (Count < 2) return;

            var values = this.ToList();
            values.Reverse();

            Clear();

            AddRange(values);
        }

        private bool RemoveNode(ChainedNode<T> target)
        {
            if (target == null)
                return false;

            var previous = FindPreviousOf(target);

            if (previous == null)
            {
                RemoveHead();
                return true;
            }

            previous.Next = target.Next;
            return true;
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
                Add(value);
                return Tail;
            }

            var previous = FindPreviousOf(target);

            if(previous == null)
            {
                AddAtStart(value);
                return Head;
            }

            return InsertValueAfter(previous, value);
        }

        private ChainedNode<T> InsertValueAfter(ChainedNode<T> target, T value)
        {
            if (target == null)
            {
                Add(value);
                return Tail;
            }

            var originalNext = target.Next;
            target.Next = new ChainedNode<T>(value);
            target.Next.Next = originalNext;

            return target.Next;
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

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            if (Head == null)
                _head = new ChainedNode<T>(item);
            else
                Tail.Next = new ChainedNode<T>(item);
        }

        public void Clear()
        {
            _head = null;
        }

        public bool Contains(T item)
        {
            return NodeOf(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach(var item in this)
            {
                array.SetValue(item, arrayIndex);
                arrayIndex += 1;
            }
        }

        
    }
}
