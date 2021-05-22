using System.Collections.Generic;

namespace LighterLinkedList.core
{
    public class LigherList<T>
    {
        public LigherList(List<T> items)
        {
            var current = Head;
            LighterNode<T> previous = null;

            for (int i = 0; i < items.Count; i++)
            {
                if(current == null)
                {
                    current = new LighterNode<T>(items[i]);
                    Head = current;
                    continue;
                }

                if(current.Value != null)
                {
                    previous = current;
                    current = new LighterNode<T>(items[i]);
                }

                if(previous != null)
                    previous.Next = current;
            }
        }

        public LighterNode<T> Head { get; set; }

        public LighterNode<T> First => Head;
    }

    public class LighterNode<T>
    {
        public LighterNode(T value)
        {
            Value = value;
            Next = null;
        }

        public T Value { get; internal set; }

        public LighterNode<T> Next { get; internal set; }
    }
}
