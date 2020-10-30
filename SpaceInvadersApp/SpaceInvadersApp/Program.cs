using SpaceInvadersApp.Controllers;
using SpaceInvadersApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceInvadersApp
{
    class Program
    {
        static GameEngine gameEngine;
        static GameSettings gameSettings;

        static UIController uIController;


        static void Main(string[] args)
        {
            Initialize();

            gameEngine.Run();
        }

        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
            uIController = new UIController();

            uIController.OnAPressed += (obj, arg) => gameEngine.CalculateMovePlaterShipLeft();
            uIController.OnDPressed += (obj, arg) => gameEngine.CalculateMovePlaterShipRight();

            Thread uIThread = new Thread(uIController.StartListening);
            uIThread.Start();
        }
    }
}
