using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal interface IData<T>
    {
        public T this[int x, int y] { get; set; }

    }
}
