namespace Utils
{
    public class GridNode<T> : IGridNode<T>
    {
        private readonly Grid<T> grid;
        public int X { get; }
        public int Y { get; }

        public GridNode(Grid<T> grid, int x, int y)
        {
            this.grid = grid;
            X = x;
            Y = y;
        }

        public T Value { get => grid.Get(X, Y); set => Set(value); }
        public void Set(T item)
        {
            grid.Set(X, Y, item);
        }

        public IEnumerable<IGridNode<T>> GetN4()
        {
            return grid.GetN4(this);
        }

        public IEnumerable<IGridNode<T>> GetN8()
        { 
            return grid.GetN8(this);
        }

        public override bool Equals(object? obj)
        {
            return obj is GridNode<T> node &&
                   EqualityComparer<Grid<T>>.Default.Equals(grid, node.grid) &&
                   X == node.X &&
                   Y == node.Y &&
                   EqualityComparer<T>.Default.Equals(Value, node.Value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Value);
        }
    }
}