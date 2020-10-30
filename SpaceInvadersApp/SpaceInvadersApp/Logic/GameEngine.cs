using SpaceInvadersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Logic
{
    class GameEngine
    {
        private bool _isNotOwer;
        private Scene _scene;

        private SceneRender _sceneRender;

        private static GameEngine _engine;
        private GameSettings _gameSettings;

        private GameEngine()
        {
        }

        private GameEngine(GameSettings gameSettings)
        {
            _isNotOwer = true;
            _gameSettings = gameSettings;
            _scene = Scene.GetScene(gameSettings);
            _sceneRender = new SceneRender(gameSettings);
        }

        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if(_engine == null)
            {
                _engine = new GameEngine(gameSettings);
            }

            return _engine;
        }

        public void Run()
        {
            int swarmMoveCounter = 0;
            do
            {
                _sceneRender.ClearScreen();
                _sceneRender.Render(_scene);

                Thread.Sleep(_gameSettings.GameSpeed);

                if (swarmMoveCounter == _gameSettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }

                swarmMoveCounter++;

            } while (_isNotOwer);

        }

        public void CalculateMovePlaterShipLeft()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate > 1)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate--;
            }
        }

        public void CalculateMovePlaterShipRight()
        {
            if (_scene.playerShip.GameObjectPlace.XCoordinate < _gameSettings.ConsoleWidth)
            {
                _scene.playerShip.GameObjectPlace.XCoordinate++;
            }
        }

        public void CalculateSwarmMove()
        {
            foreach (var alienShip in _scene.swarm)
            {
                alienShip.GameObjectPlace.YCoordinate++;

                if (alienShip.GameObjectPlace.YCoordinate == _scene.playerShip.GameObjectPlace.YCoordinate)
                {
                    _isNotOwer = false;
                }
            }
        }
    }
}
