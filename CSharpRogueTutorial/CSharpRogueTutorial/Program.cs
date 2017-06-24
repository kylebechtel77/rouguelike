using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal = BearLib.Terminal;

namespace RogueTutorial
{
    class Program
    {
        private static void Initialize()
        {
            Terminal.Open();
            Terminal.Set("window: size=80x30; font: VeraMono.ttf, size=12");
        }

        private static void MainLoop()
        {
            while (true)
            {
                Terminal.Clear();
                Terminal.PutExt(0, 0, 0, 0, '@');
                Terminal.Refresh();
            }
        }

        static void Main(string[] args)
        {
            Initialize();
            MainLoop();
        }
    }
}
