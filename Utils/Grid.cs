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

        public (IEnumerable<IGridNode<T>>, int Cost) GetClosestPath(int sx, int sy, int ex, int ey, Func<(int X,int Y), (int X, int Y), IGrid<T>, int> cost)
        {
            var dist = new Dictionary<(int x, int y), int>();
            var prev = new Dictionary<(int x, int y), (int x, int y)>();
            var prioQ = new PriorityQueue<(int x, int y), int>();

            InitStateDijkstra(sx, sy, dist, prioQ);

            while (prioQ.Count > 0)
            {
                var u = prioQ.Dequeue();
                foreach (var n in GetN4(u.x, u.y))
                {
                    var (x, y) = (n.X, n.Y);
                    var alt = dist[u] + cost(u, (x, y), this);
                    if (alt < dist[(x, y)])
                    {
                        dist[(x, y)] = alt;
                        prev[(x, y)] = u;
                        prioQ.Enqueue((x, y), alt);
                    }
                }
            }

            return GeneratePathAndCost(ex, ey, cost, prev);
        }

        public (IEnumerable<IGridNode<T>>, int Cost) GetClosestPath((int X, int Y) start, (int X, int Y) goal, Func<(int X, int Y), (int X, int Y), IGrid<T>, int> cost = null, Func<(int X, int Y), IGrid<T>, int> heuristic = null)
        {
            var c = cost ?? ((_,_,_) => 1);
            if(heuristic == null)
            {
                return GetClosestPath(start.X, start.Y, goal.X, goal.Y, c);
            }
            else
            {
                return GetClosestPath(start.X, start.Y, goal.X, goal.Y, c);
            }
        }

        public (IEnumerable<IGridNode<T>>, int Cost) GetClosestPath(int sx, int sy, int ex, int ey, Func<(int X, int Y), (int X, int Y), IGrid<T>, int> cost, Func<(int X, int Y), IGrid<T>, int> heuristic)
        {
            var gScore = new Dictionary<(int x, int y), int>();
            var prev = new Dictionary<(int x, int y), (int x, int y)>();
            var prioQ = new PriorityQueue<(int x, int y), int>();
            var fScore = new Dictionary<(int x, int y), int>();
            InitStateAStar(sx, sy, heuristic, gScore, prioQ, fScore);

            while (prioQ.Count > 0)
            {
                var u = prioQ.Dequeue();
                if (u == (ex, ey)) break;
                foreach (var n in GetN4(u.x, u.y))
                {
                    var (x, y) = (n.X, n.Y);
                    var alt = gScore[u] + cost(u, (x, y), this);
                    if (alt < gScore[(x, y)])
                    {
                        gScore[(x, y)] = alt;
                        fScore[(x, y)] = alt + heuristic((x, y), this);
                        prev[(x, y)] = u;
                        prioQ.Enqueue((x, y), alt);
                    }
                }
            }

            return GeneratePathAndCost(ex, ey, cost, prev);
        }

        private void InitStateDijkstra(int sx, int sy, Dictionary<(int x, int y), int> dist, PriorityQueue<(int x, int y), int> prioQ)
        {
            dist[(sx, sy)] = 0;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var t = (x, y);
                    if (x != 0 || y != 0)
                    {
                        dist[t] = int.MaxValue;
                    }

                    prioQ.Enqueue(t, dist[t]);
                }
            }
        }

        private void InitStateAStar(int sx, int sy, Func<(int X, int Y), IGrid<T>, int> heuristic, Dictionary<(int x, int y), int> gScore, PriorityQueue<(int x, int y), int> prioQ, Dictionary<(int x, int y), int> fScore)
        {
            fScore[(sx, sy)] = heuristic((sx, sy), this);
            gScore[(sx, sy)] = 0;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var t = (x, y);
                    if (x != 0 || y != 0)
                    {
                        gScore[t] = int.MaxValue;
                        fScore[t] = int.MaxValue;
                    }

                    prioQ.Enqueue(t, fScore[t]);
                }
            }
        }

        private (IEnumerable<IGridNode<T>>, int Cost) GeneratePathAndCost(int ex, int ey, Func<(int X, int Y), (int X, int Y), IGrid<T>, int> cost, Dictionary<(int x, int y), (int x, int y)> prev)
        {
            var rv = new List<IGridNode<T>>();
            rv.Add(GetNode(ex, ey));
            while (prev.ContainsKey((rv[^1].X, rv[^1].Y)))
            {
                var t = prev[(rv[^1].X, rv[^1].Y)];
                rv.Add(GetNode(t.x, t.y));
            }

            rv.Reverse();
            int c = 0;
            for (int i = 0; i < rv.Count - 1; i++)
            {
                var n1 = rv[i];
                var n2 = rv[i + 1];
                c += cost((n1.X, n1.Y), (n2.X, n2.Y), this);
            }

            return (rv, c);
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