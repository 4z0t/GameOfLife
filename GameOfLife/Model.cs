using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Model
    {
        private Data data;
        public Model() { 
            data = new Data();
        }

        public int[,] getGrid()
        {
            return data.getGrid();
        }

        public void Reset(int size) // установка всех клеток пустыми
        {
            data.OpenReset(size);
        }

        public int GetCell(int x, int y)
        {
            return data.GetCell(x, y);
        }

        public void SetCell(int x, int y, int value)
        {
            data.SetCell(x, y, value);
        }

        public void TransformSize(int newSize) //перенос данных в таблицу нового размера
        {
            data.TransformSize(newSize);
        }

        public int Update(){ // 1 тик
            return data.Update();
        }
    }
}
