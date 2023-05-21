using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Controller
    {
        Model model;
        View view;
        public Controller() {
            model = new Model();
            view = new View();

        }

        public void Render() { 
            
            view.Render();
        } // отрисовка окна

        public void Update() { 
            model.Update();
            view.Update(model.getGrid()); // пока хз как будем передавать данные
        } // 1 шаг алгоритма

        public void GetData(int x, int y) // получение значения на клетке
        {
           
        }

        public void GridChange(int gridSize)  // установка параметра слайдером
        { // установка параметра слайдером

        }

        public void TimeChange(int CycleTime) // установка параметра слайдером
        { 

        }

        public void Reset() {  } // Обновление всех данных(для кнопки Стереть Всё)

    }
}
