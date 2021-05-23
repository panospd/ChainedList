# ChainedList

```
  // Examples


  // Creates empty list
  var ChainedList = new ChainedList<int>();

  // Preloaded list
  var ChainedList = new ChainedList<int>(new List<int> { 1, 2, 4 });

  // Adds 5 at the end of list
  ChainedList.Insert(5);

  // Adds nodes with values of 6 and 7 at the end of the list
  ChainedList.InsertRange(new List<int> { 6, 7 });

  // Returns the head (first) value in the list
  ChainedList.Head;

  // Returns the tail (last) value in the list
  ChainedList.Tail;

  // Returns the nodes count
  ChainedList.Count;

  // Add node with value of 8 as the second node in the list
  ChainedList.InsertAfter(ChainedList.Head, 8);

  // Add node with value of 8 after the first node with a value of 2
  ChainedList.InsertAfter(node => node.value == 2, 8);

  // Add nodes with values of 8 and 10 after the first node with a value of 2
  ChainedList.InsertAfter(node => node.value == 2, new int[] { 8, 10 });

  // Removes first node with a value of 2
  ChainedList.Remove(2);

  // Removes all nodes from list
  ChainedList.RemoveAll();

  // Removes all nodes from list, whose values are 1
  ChainedList.RemoveAll(node => node.Value == 1);

  // Returns a List<string> containing the string representations for each node
  ChainedList.PrintList();

  // Returns a List<T> containing the values for each node
  ChainedList.ToList();

  // Returns true if list is empty
  ChainedList.IsEmpty;

  // Returns true if list is not empty
  ChainedList.Any();

  // Returns the first node that has a value of 2
  ChainedList.Find(2);
  or
  ChainedList.Find(value => value == 2);
```
