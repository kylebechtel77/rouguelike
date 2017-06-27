using BearLib;
using System.Linq;

namespace CSharpRogueTutorial
{
    class Controls
    {
        static int[] LeftMovement = { Terminal.TK_LEFT, Terminal.TK_KP_4, Terminal.TK_H };
        static int[] RightMovement = { Terminal.TK_RIGHT, Terminal.TK_KP_6, Terminal.TK_L };
        static int[] UpMovement = { Terminal.TK_UP, Terminal.TK_KP_8, Terminal.TK_K };
        static int[] DownMovement = { Terminal.TK_DOWN, Terminal.TK_KP_2, Terminal.TK_J };

        public static int[] EscapeKeys = { Terminal.TK_ESCAPE };

        public static bool HandleKeys(GameObject player)
        {
            int key = Terminal.Read();

            if (LeftMovement.Contains(key))
            {
                player.Move(-1, 0);
            }
            else if (RightMovement.Contains(key))
            {
                player.Move(1, 0);
            }
            else if (UpMovement.Contains(key))
            {
                player.Move(0, -1);
            }
            else if (DownMovement.Contains(key))
            {
                player.Move(0, 1);
            }

            else if (EscapeKeys.Contains(key))
            {
                return true;
            }

            return false;
        }
    }
}
