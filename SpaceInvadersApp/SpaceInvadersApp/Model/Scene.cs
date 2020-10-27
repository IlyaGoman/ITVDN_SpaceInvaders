using SpaceInvadersApp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Model
{
    class Scene
    {
        List<GameObject> _swarm;
        List<GameObject> _groud;
        GameObject _playerShip;
        List<GameObject> _playerShipMissile;

        GameSettings _gameSettings;

        private static Scene _scene;

        private Scene() {}

        private Scene(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _swarm = new AlienShipFactory(_gameSettings).GetSwarm();
            _groud = new GroundFactory(_gameSettings).GetGround();
            _playerShip = new PlayerShipFactory(_gameSettings).GetPlayerShip();

        }

        public static Scene GetScene(GameSettings gameSettings)
        {
            if(_scene == null)
            {
                _scene = new Scene(gameSettings);
            }

            return _scene;
        }
    }
}
