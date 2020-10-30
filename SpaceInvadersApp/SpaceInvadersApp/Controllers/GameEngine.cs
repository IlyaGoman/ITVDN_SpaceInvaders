using SpaceInvadersApp.Factories;
using SpaceInvadersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Controllers
{
    class GameEngine
    {
        private bool _isNotOver;
        private Scene _scene;

        private SceneRender _sceneRender;

        private static GameEngine _engine;
        private GameSettings _gameSettings;

        private GameEngine()
        {
        }

        private GameEngine(GameSettings gameSettings)
        {
            _isNotOver = true;
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
            int playerMissileCounter = 0;
            do
            {
                _sceneRender.Render(_scene);

                Thread.Sleep(_gameSettings.GameSpeed);

                if (swarmMoveCounter == _gameSettings.SwarmSpeed)
                {
                    CalculateSwarmMove();
                    swarmMoveCounter = 0;
                }

                if(playerMissileCounter == _gameSettings.PlayerMissileSpeed)
                {
                    CalculateMissileMove();
                    playerMissileCounter = 0;
                }

                playerMissileCounter++;
                swarmMoveCounter++;

            } while (_isNotOver);

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
                    _isNotOver = false;
                    _sceneRender.RenderGameOver();
                    break;
                }
            }
        }

        public void Shot()
        {
            PlayerShipMissileFactory missileFactory = new PlayerShipMissileFactory(_gameSettings);
            GameObject missile = missileFactory.GetGameObject(_scene.playerShip.GameObjectPlace);

            _scene.playerShipMissile.Add(missile);

            //Console.Beep(1000, 200);
        }

        public void CalculateMissileMove()
        {
            if(_scene.playerShipMissile.Count > 0)
            {
                for(int i=0; i< _scene.playerShipMissile.Count; i++)
                {
                    GameObject missile = _scene.playerShipMissile[i];

                    if(missile.GameObjectPlace.YCoordinate == 1)
                    {
                        _scene.playerShipMissile.RemoveAt(i);
                    }

                    missile.GameObjectPlace.YCoordinate--;

                    for(int j = 0; j< _scene.swarm.Count; j++)
                    {
                        GameObject alienShip = _scene.swarm[j];

                        if(missile.GameObjectPlace.Equals(alienShip.GameObjectPlace))
                        {
                            _scene.swarm.RemoveAt(j);
                            _scene.playerShipMissile.RemoveAt(i);

                            break;
                        }
                    }
                }
            }
        }
    }
}
