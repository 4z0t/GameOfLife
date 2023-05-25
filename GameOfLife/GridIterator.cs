using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class GridIterator<T> : IEnumerable<(int, int, T)>
    {
        public GridIterator(IModelGridData<T> data)
        {
            _data = data;
        }

        public IEnumerator<(int, int, T)> GetEnumerator()
        {
            (int curX, int curY) = _data.GetStartIndex();
            bool hasNext = true;
            while (hasNext)
            {
                int x = curX;
                int y = curY;
                T v = _data[x, y];
                (hasNext, curX, curY) = _data.Next(x, y);
                yield return (x, y, v);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IModelGridData<T> _data;
    }
}
