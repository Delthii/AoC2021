namespace Utils
{
    public interface IGridNode<T>
    {
        int X { get; }
        int Y { get; }
        T Value { get; }

        void Set(T item);
    }
}