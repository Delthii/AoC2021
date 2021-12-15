﻿namespace Utils
{
    public interface IGrid<T>
    {
        public int Width { get; }
        public int Height { get; }
        void Set(int x, int y, T item);
        bool TrySet(int x, int y, T item);
        IEnumerable<IGridNode<T>> GetConnectedComponent(int x, int y, Func<T, bool> predicate);
        (IEnumerable<IGridNode<T>>, int Cost) GetClosestPath(int sx, int sy, int ex, int ey, Func<(int X, int Y), (int X, int Y), IGrid<T>, int> cost);
        T Get(int x, int y);
        IGridNode<T> GetNode(int x, int y);
        bool TryGet(int x, int y, out T? item);
        IEnumerable<IGridNode<T>> GetN8(int x, int y);
        IEnumerable<IGridNode<T>> GetN4(IGridNode<T> node);
        IEnumerable<IGridNode<T>> GetN4(int x, int y);
        IEnumerable<IGridNode<T>> GetN8(IGridNode<T> node);
    }
}