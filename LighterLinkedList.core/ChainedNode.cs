namespace ChainedList.core
{
    public class ChainedNode<T>
    {
        public ChainedNode(T value)
        {
            Value = value;
            Next = null;
        }

        public T Value { get; internal set; }

        public ChainedNode<T> Next { get; internal set; }
    }
}
