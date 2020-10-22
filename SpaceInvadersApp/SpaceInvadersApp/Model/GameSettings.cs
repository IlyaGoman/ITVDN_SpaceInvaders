using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersApp.Model
{
    class GameSettings
    {
        #region MainInfo
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public int ConsoleWidth { get; set; } = 80;

        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public int ConsoleHeight { get; set; } = 30;

        public int GameSpeed { get; set; } = 100;
        #endregion

        #region AlienInfo
        /// <summary>
        /// Число рядов кораблей пришельцев
        /// </summary>
        public int NumberOfSwarmRows { get; set; } = 2;

        /// <summary>
        /// Число кораблей пришельцев
        /// </summary>
        public int NumberOfSwarmColls { get; set; } = 60;

        /// <summary>
        /// Начальная точка расположения кораблей пришельцев по оси Х
        /// </summary>
        public int SwarmStartXCoordinate { get; set; } = 10;

        /// <summary>
        /// Начальная точка расположения кораблей пришельцев по оси Y
        /// </summary>
        public int SwarmStartYCoordinate { get; set; } = 2;

        /// <summary>
        /// Обозначение корабля пришельцев
        /// </summary>
        public char AlienShip { get; set; } = 'O';

        /// <summary>
        /// Скорость движения кораблей пришельцев
        /// </summary>
        public int SwarmSpeed { get; set; } = 20; 
        #endregion

        #region PlayerInfo
        /// <summary>
        /// Начальная точка расположения корабля игрока по оси Х
        /// </summary>
        public int PlayerStartXCoordinate { get; set; } = 40;

        /// <summary>
        /// Начальная точка расположения корабля игрока по оси Y
        /// </summary>
        public int PlayerStartYCoordinate { get; set; } = 19;

        /// <summary>
        /// Обозначение корабля игрока
        /// </summary>
        public char PlayerShip { get; set; } = '^';

        /// <summary>
        /// Обозначение ракеты игрока
        /// </summary>
        public char PlayerMissile { get; set; } = '|';

        /// <summary>
        /// Скорость ракеты игрока
        /// </summary>
        public int PlayerMissileSpeed { get; set; } = 5;
        #endregion


        #region GroundInfo
        public int GroundStartXCoordinate { get; set; } = 1;

        public int GroundStartYCoordinate { get; set; } = 20;

        /// <summary>
        /// Обозначение земли
        /// </summary>
        public char Ground { get; set; } = 'П';

        /// <summary>
        /// Число рядов земли
        /// </summary>
        public int NumberOfGroundRows { get; set; } = 1;
        #endregion
    }
}
