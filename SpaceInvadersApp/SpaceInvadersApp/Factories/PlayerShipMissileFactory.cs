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
            GameObject playerMissile = new PlayerShipMissile() { Figure = GameSettings.PlayerMissile, GameObjectPlace = gameObjectPlace, GameObjectType = GameObjectType.PlayerShipMissile };

            return playerMissile;
        }
    }
}
