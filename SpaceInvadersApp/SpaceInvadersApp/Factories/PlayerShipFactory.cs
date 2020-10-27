using SpaceInvadersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Factories
{
    class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        public override GameObject GetGameObject(GameObjectPlace gameObjectPlace)
        {
            GameObject playerObject = new GroundObject() { Figure = GameSettings.PlayerShip, GameObjectPlace = gameObjectPlace, GameObjectType = GameObjectType.PlayerShip };

            return playerObject;
        }

        public GameObject GetPlayerShip()
        {
            int startX = GameSettings.PlayerStartXCoordinate;
            int startY = GameSettings.PlayerStartYCoordinate;

            GameObjectPlace gameObjectPlace = new GameObjectPlace() { XCoordinate = startX, YCoordinate = startY };
            GameObject playerShip = GetGameObject(gameObjectPlace);

            return playerShip;
        }
    }
}
