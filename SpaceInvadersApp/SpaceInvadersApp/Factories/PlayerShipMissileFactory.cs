using SpaceInvadersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Factories
{
    class PlayerShipMissileFactory : GameObjectFactory
    {
        public PlayerShipMissileFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        public override GameObject GetGameObject(GameObjectPlace gameObjectPlace)
        {
            GameObjectPlace missilePlace = new GameObjectPlace() { XCoordinate = gameObjectPlace.XCoordinate, YCoordinate = gameObjectPlace.YCoordinate-1 };

            GameObject playerMissile = new PlayerShipMissile() { Figure = GameSettings.PlayerMissile, GameObjectPlace = missilePlace, GameObjectType = GameObjectType.PlayerShipMissile };

            return playerMissile;
        }
    }
}
