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
        public List<GameObject> swarm;
        public List<GameObject> groud;
        public GameObject playerShip;
        public List<GameObject> playerShipMissile;

        GameSettings _gameSettings;

        private static Scene _scene;

        private Scene() {}

        private Scene(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            swarm = new AlienShipFactory(_gameSettings).GetSwarm();
            groud = new GroundFactory(_gameSettings).GetGround();
            playerShip = new PlayerShipFactory(_gameSettings).GetPlayerShip();

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
