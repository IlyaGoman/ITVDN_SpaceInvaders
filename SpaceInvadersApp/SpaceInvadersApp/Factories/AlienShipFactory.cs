using SpaceInvadersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Factories
{
    class AlienShipFactory : GameObjectFactory
    {
        public AlienShipFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        public override GameObject GetGameObject(GameObjectPlace gameObjectPlace)
        {
            GameObject alienShip = new AlienShip() { Figure = GameSettings.AlienShip, GameObjectPlace = gameObjectPlace, GameObjectType = GameObjectType.AlienShip };

            return alienShip;
        }

        public List<GameObject> GetSwarm()
        {
            List<GameObject> swarm = new List<GameObject>();

            int startX = GameSettings.SwarmStartXCoordinate;
            int startY = GameSettings.SwarmStartYCoordinate;

            for (int y = 0; y < GameSettings.NumberOfSwarmRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfSwarmColls; x++)
                {
                    GameObjectPlace gameObjectPlace = new GameObjectPlace() { XCoordinate = startX + x, YCoordinate = startY + y };
                    GameObject alienShip = GetGameObject(gameObjectPlace);

                    swarm.Add(alienShip);
                }
            }

            return swarm;
        }
    }
}
