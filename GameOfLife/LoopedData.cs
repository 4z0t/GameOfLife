using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class LoopedData<T> : IModelGridData<T>
    {
        public LoopedData(int size)
        {
            _grid = new T[size, size];
        }

        public LoopedData(LoopedData<T> other)
        {
            _grid = (T[,])other._grid.Clone();
        }

        public T this[int x, int y]
        {
            get
            {
                (x, y) = ClampIndex(x, y);
                return _grid[x, y];
            }
            set
            {
                (x, y) = ClampIndex(x, y);
                _grid[x, y] = value;
            }
        }

        public (int, int) ClampIndex(int x, int y)
        {
            if (x < 0)
                x = (1 - x / _grid.GetLength(0)) * _grid.GetLength(0) + x;
            if (y < 0)
                y = (1 - y / _grid.GetLength(1)) * _grid.GetLength(1) + y;

            x = x % _grid.GetLength(0);
            y = y % _grid.GetLength(1);
            return (x, y);
        }

        public (int, int) GetStartIndex()
        {
            return (0, 0);
        }

        public (bool, int, int) Next(int x, int y)
        {
            if (x + 1 != _grid.GetLength(0)) return (true, x + 1, y);

            if (y + 1 != _grid.GetLength(1)) return (true, 0, y + 1);

            return (false, 0, 0);
        }

        public IModelGridData<T> Clone()
        {
            LoopedData<T> clone = new(this);
            return clone;
        }

        private T[,] _grid;
    }
}
