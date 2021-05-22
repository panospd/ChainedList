namespace LighterLinkedList.core
{
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
