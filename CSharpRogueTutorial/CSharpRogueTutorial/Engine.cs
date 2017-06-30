﻿using CSharpRogueTutorial;
using System.Collections.Generic;
using BearLib;

namespace RogueTutorial
{
    class Rogue
    {
        public static World GameWorld;

        private static void Initialize()
        {
            Terminal.Open();
            Terminal.Set("window: size=" + Constants.ScreenWidth + "x" + Constants.ScreenHeight + "; font: VeraMono.ttf, size=12");
        }

        private static void NewGame()
        {
            GameWorld = new World();

            GameWorld.Objects = new List<GameObject>();

            GameWorld.Player = new GameObject('@', "red", 0, 0);
            GameWorld.Objects.Add(GameWorld.Player);

            GameWorld.Map = MapCreation.MakeMaze();
        }

        private static void MainLoop()
        {
            while (true)
            {
                Rendering.RenderAll();

                bool exit = InputHandlers.HandleKeys();

                if (exit)
                {
                    break;
                }
            }

            Terminal.Close();
        }

        static void Main(string[] args)
        {
            Initialize();
            NewGame();
            MainLoop();
        }
    }
}
