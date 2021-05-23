# LighterList

```
  // Examples
  
  
  // Empty list
  var lighterList = new LighterList<int>();
  
  // Preloaded list
  var lighterList = new LighterList<int>(new List<int> { 1, 2, 4 });
  
  // Adds 5 at the end of list
  lighterlist.Insert(5);
  
  // Adds nodes with values of 6 and 7 at the end of the list
  lighterlist.InsertRange(new List<int> { 6, 7 });
  
  // Returns the head (first) value in the list
  lighterlist.Head;
  
  // Returns the tail (last) value in the list
  lighterlist.Tail;
  
  // Returns the nodes count
  lighterlist.Count;
  
  // Add node with value of 8 as the second node in the list
  lighterList.InsertAfter(lighterList.Head, 8);
  
  // Add node with value of 8 after the first node with a value of 2
  lighterList.InsertAfter(node => node.value == 2, 8);
  
  // Add nodes with values of 8 and 10 after the first node with a value of 2
  lighterList.InsertAfter(node => node.value == 2, new int[] { 8, 10 });
  
  // Removes first node with a value of 2
  lighterList.Remove(2);
  
  // Removes all nodes from list
  lighterList.RemoveAll();
  
  // Removes all nodes from list, whose values are 1
  lighterList.RemoveAll(node => node.Value == 1);
  
  // Returns a List<string> containing the string representations for each node
  lighterList.PrintList();
  
  // Returns a List<T> containing the values for each node
  lighterList.ToList();
  
  // Returns true if list is empty
  lighterList.IsEmpty;
  
  // Returns true if list is not empty
  lighterList.Any();
  
  // Returns the first node that has a value of 2
  lighterList.Find(2);
  or
  lighterList.Find(value => value == 2);
```
