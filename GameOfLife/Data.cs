using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Data
    {
        private int[,] grid;
        private int gridSize;

        public Data() {
            gridSize = 30;
            Reset(gridSize);
        }

        public int[,] getGrid(){
            return grid;
        }

        public void OpenReset(int size){
            if (size > 0 && size <= 100){ 
                Reset(gridSize);
            }
            else if (size > 100) { 
                Reset(100); 
            }
        }

        private void Reset(int size) // установка всех клеток пустыми
        {
            int[,] grid = new int[size, size];
            gridSize = size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = 0;
                }
            }
        }

        public int GetCell(int x, int y) {
            if (x>=0 && y>=0 && x < gridSize && y < gridSize)
                return grid[x, y];
            else{
            // тут мб надо ошибку вернуть
                return 0;
            }
        }


        public void SetCell(int x, int y, int value)
        {
            if (x >= 0 && y >= 0 && x < gridSize && y < gridSize)
                grid[x, y] = value;
            else
            {
                // тут мб надо ошибку вернуть
                return;
            }
        }

        public void TransformSize(int newSize) //перенос данных в таблицу нового размера
        {
            if (newSize > 0) {
                int[,] oldGrid = grid;

                int oldSize = gridSize;

                Reset(newSize);

                int changeSize = 0;

                if (newSize > oldSize) {
                    changeSize = oldSize;
                }
                else{
                    changeSize = newSize;
                }

                for (int i = 0; i < changeSize; i++){ 
                    for (int j = 0; j < changeSize; j++)
                    {
                        grid[i,j] = oldGrid[i,j];
                    }
                }
            }
        }

        public void Update(){ // здесь будут производиться вычисления для след. шагов
            
        }
    }
}
