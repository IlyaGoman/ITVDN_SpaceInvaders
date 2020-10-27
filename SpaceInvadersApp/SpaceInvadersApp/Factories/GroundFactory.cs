using SpaceInvadersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Factories
{
    class GroundFactory : GameObjectFactory
    {
        public GroundFactory(GameSettings gameSettings)
            : base(gameSettings)
        {

        }

        public override GameObject GetGameObject(GameObjectPlace gameObjectPlace)
        {
            GameObject groundObject = new GroundObject() { Figure = GameSettings.Ground, GameObjectPlace = gameObjectPlace, GameObjectType = GameObjectType.GroudObject };

            return groundObject;
        }

        public List<GameObject> GetGround()
        {
            List<GameObject> ground = new List<GameObject>();

            int startX = GameSettings.GroundStartXCoordinate;
            int startY = GameSettings.GroundStartYCoordinate;

            for (int y = 0; y < GameSettings.NumberOfGroundRows; y++)
            {
                for (int x = 0; x < GameSettings.NumberOfGroundColls; x++)
                {
                    GameObjectPlace gameObjectPlace = new GameObjectPlace() { XCoordinate = startX + x, YCoordinate = startY + y };
                    GameObject groundObject = GetGameObject(gameObjectPlace);

                    ground.Add(groundObject);
                }
            }

            return ground;
        }
    }
}
