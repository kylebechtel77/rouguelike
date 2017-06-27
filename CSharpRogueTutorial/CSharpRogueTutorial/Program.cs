using CSharpRogueTutorial;
using RogueSharp;
using System.Collections.Generic;
using BearLib;

namespace RogueTutorial
{
    class Rogue
    {
        public static GameObject player;
        public static List<GameObject> objects;
        public static Map map;

        private static void Initialize()
        {
            Terminal.Open();
            Terminal.Set("window: size=" + Constants.ScreenWidth.ToString() + "x" + Constants.ScreenHeight.ToString() + "; font: VeraMono.ttf, size=12");

            objects = new List<GameObject>();

            player = new GameObject('@', "red", 0, 0);
            objects.Add(player);

            map = MapCreation.MakeMap();
        }

        private static void MainLoop()
        {
            while (true)
            {
                Rendering.RenderAll();

                bool exit = Controls.HandleKeys(player);

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
            MainLoop();
        }
    }
}
