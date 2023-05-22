﻿using System;
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
        private int AliveCounter;

        public Data() {
            gridSize = 30;
            AliveCounter = 0;
            Reset(gridSize);
        }

        public int[,] getGrid(){
            return grid;
        }

        private void changeCounter(int newCount){
            if (newCount == 1 && AliveCounter+1<=gridSize*gridSize){
                AliveCounter += 1;
            }
            else if (newCount == -1 && AliveCounter - 1 >= 0)
            {
                AliveCounter -= 1;
            }
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
            AliveCounter = 0;
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
            {
                if (value == 1 && grid[x, y]==0)
                {
                    changeCounter(1);
                }
                grid[x, y] = value;
            }
            // тут мб надо ошибку вернуть 
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

        public int Update(){ // здесь будут производиться вычисления для след. шагов
            
            // 0 - игра продолжается
            // 1 - игра прекращается
            // 2 - повторение конфигурации
            // 3 - непредвиденная ошибка
            
            int count = 0;
            int[,] oldGrid = grid;
            // без краёв области
            for (int i = 1; i < gridSize - 1; i++) {
                for (int j = 1; j < gridSize - 1; j++) {
                    count = oldGrid[i, j - 1] + oldGrid[i - 1, j] + oldGrid[i + 1, j] + oldGrid[i, j + 1];
                    if (count == 3 && oldGrid[i, j] == 0)
                    {
                        grid[i, j] = 1;
                        changeCounter(1);
                    }
                    else if ((count == 2 || count == 3) && oldGrid[i, j] == 1)
                    {
                    }
                    else{
                        grid[i, j] = 0;
                        changeCounter(-1);
                    }
                }
            }

            //1 из крайних сторон
            for (int j = 1; j < gridSize - 1; j++)
            {
                count = oldGrid[0, j - 1] + oldGrid[1, j] + oldGrid[0, j + 1];
                if (count == 3 && oldGrid[0, j] == 0)
                {
                    grid[0, j] = 1;
                    changeCounter(1);
                }
                else if ((count == 2 || count == 3) && oldGrid[0, j] == 1)
                {
                }
                else
                {
                    grid[0, j] = 0;
                    changeCounter(-1);
                }
            }

            if (AliveCounter==0){
                return 1;
            }
            return 0;
        }
    }
}
