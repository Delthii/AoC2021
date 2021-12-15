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

        public T Value { get => grid.Get(X, Y); set => grid.Set(X, Y, value); }

        public IEnumerable<IGridNode<T>> GetN()
        {
            return grid.GetN(X, Y);
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