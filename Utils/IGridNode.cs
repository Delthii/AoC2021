namespace Utils
{
    public interface IGridNode<T>
    {
        int X { get; }
        int Y { get; }
        T Value { get; set; }

        void Set(T item);
        IEnumerable<IGridNode<T>> GetN4();
        IEnumerable<IGridNode<T>> GetN8();
    }
}