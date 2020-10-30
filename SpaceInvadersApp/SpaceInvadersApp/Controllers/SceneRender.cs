﻿using SpaceInvadersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Controllers
{
    class SceneRender
    {
        int _screenWidth;
        int _screenHeight;

        char[,] _screenMatrix;

        public SceneRender(GameSettings gameSettings)
        {
            _screenWidth = gameSettings.ConsoleWidth ;
            _screenHeight = gameSettings.ConsoleHeight ;
            _screenMatrix = new char[gameSettings.ConsoleHeight, gameSettings.ConsoleWidth];

            Console.WindowHeight = gameSettings.ConsoleHeight;
            Console.WindowWidth = gameSettings.ConsoleWidth;
            
            ResetPosition();
        }

        private static void ResetPosition()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }

        public void Render(Scene scene)
        {
            ClearScreen();
            ResetPosition();

            AddListForRendering(scene.swarm);
            AddListForRendering(scene.groud);
            AddListForRendering(scene.playerShipMissile);

            AddGameObjectForRendering(scene.playerShip);

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    stringBuilder.Append(_screenMatrix[y,x]);
                }

                stringBuilder.Append(Environment.NewLine);
            }

            Console.WriteLine(stringBuilder.ToString());

            ResetPosition();
        }

        /// <summary>
        /// Добавляет объект на игровой экран.
        /// </summary>
        /// <param name="gameObject">Добавляемый объект</param>
        public void AddGameObjectForRendering(GameObject gameObject)
        {
            if(gameObject.GameObjectPlace.YCoordinate < _screenMatrix.GetLength(0) &&
                gameObject.GameObjectPlace.XCoordinate < _screenMatrix.GetLength(1))
            {
                _screenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] = gameObject.Figure;
            }
            else
            {
                _screenMatrix[gameObject.GameObjectPlace.YCoordinate, gameObject.GameObjectPlace.XCoordinate] = ' ';
            }
        }

        /// <summary>
        /// Добавляет коллекцию объектов на игровой экран
        /// </summary>
        /// <param name="gameObjects"></param>
        public void AddListForRendering(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                AddGameObjectForRendering(gameObject);
            }
        }

        public void ClearScreen()
        {
            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    _screenMatrix[y, x] = ' ';
                }
            }
        }

        public void RenderGameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("GAME OVER");

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
