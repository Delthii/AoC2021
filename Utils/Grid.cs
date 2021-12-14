namespace Utils
{
    public class Grid<T> : IGrid<T>
    {
        private readonly T[][] grid;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public T this[int x, int y] { get => Get(x, y); set => Set(x, y, value); }

        public Grid(IEnumerable<IEnumerable<T>> rowsAndCols)
        {
            grid = rowsAndCols.Select(row => row.ToArray()).ToArray();
            Width = grid[0].Length;
            Height = grid.Length;
        }

        public Grid(int width, int height, T fill)
        {
            Width = width;
            Height = height;
            grid = new T[height].Select(x => new T[width].Select(item => fill).ToArray()).ToArray();
        }

        public void Set(int x, int y, T item) 
        {
            grid[y][x] = item;
        }

        public bool TrySet(int x, int y, T item)
        {
            if(x >= 0 && x < Width && y >= 0 && y < Height)
            {
                grid[y][x] = item;
                return true;
            }

            return false;
        }

        public IEnumerable<IGridNode<T>> GetConnectedComponent(int x, int y, Func<T, bool> predicate)
        {
            var cc = new HashSet<IGridNode<T>>();
            var stack = new Stack<IGridNode<T>>();
            var root = GetNode(x, y);
            stack.Push(root);
            cc.Add(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                foreach(var n in GetN4(node))
                {
                    if (predicate(n.Value) && !cc.Contains(n))
                    {
                        cc.Add(n);
                        stack.Push(n);
                    }
                }
            }

            return cc;
        }

        public T Get(int x, int y)
        {
            return grid[y][x];
        }

        public IGridNode<T> GetNode(int x, int y)
        {
            return new GridNode<T>(this, x, y);
        }

        public bool TryGet(int x, int y, out T? item)
        {
            if (InsideGrid(x, y))
            {
                item = grid[y][x];
                return true;
            }

            item = default(T);
            return false;
        }
        
        public IEnumerable<IGridNode<T>> GetN8(int x, int y)
        {
            var N = new List<GridNode<T>>();

            if (InsideGrid(x - 1, y))       N.Add(new GridNode<T>(this, x - 1, y));
            if (InsideGrid(x + 1, y))       N.Add(new GridNode<T>(this, x + 1, y));
            if (InsideGrid(x, y - 1))       N.Add(new GridNode<T>(this, x, y - 1));
            if (InsideGrid(x, y + 1))       N.Add(new GridNode<T>(this, x, y + 1));
            if (InsideGrid(x - 1, y - 1))   N.Add(new GridNode<T>(this, x - 1, y - 1));
            if (InsideGrid(x + 1, y + 1))   N.Add(new GridNode<T>(this, x + 1, y + 1));
            if (InsideGrid(x + 1, y - 1))   N.Add(new GridNode<T>(this, x + 1, y - 1));
            if (InsideGrid(x - 1, y + 1))   N.Add(new GridNode<T>(this, x - 1, y + 1));

            return N;
        }

        public IEnumerable<IGridNode<T>> GetN4(IGridNode<T> node)
        {
            return GetN4(node.X, node.Y);
        }

        public IEnumerable<IGridNode<T>> GetN4(int x, int y)
        {
            var N = new List<GridNode<T>>();

            if (InsideGrid(x - 1, y)) N.Add(new GridNode<T>(this, x - 1, y));
            if (InsideGrid(x + 1, y)) N.Add(new GridNode<T>(this, x + 1, y));
            if (InsideGrid(x, y - 1)) N.Add(new GridNode<T>(this, x, y - 1));
            if (InsideGrid(x, y + 1)) N.Add(new GridNode<T>(this, x, y + 1));

            return N;
        }

        public IEnumerable<IGridNode<T>> GetN8(IGridNode<T> node)
        {
            return GetN8(node.X, node.Y);
        }

        private bool InsideGrid(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}