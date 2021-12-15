namespace Utils
{
    public interface IGridNode<T>
    {
        int X { get; }
        int Y { get; }
        T Value { get; set; }
        public IEnumerable<IGridNode<T>> GetN();
    }
}