﻿using SpaceInvadersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Factories
{
    abstract class GameObjectFactory
    {
        public GameSettings GameSettings { get; set; }

        public abstract GameObject GetGameObject(GameObjectPlace gameObjectPlace);

        public GameObjectFactory(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }
    }
}
