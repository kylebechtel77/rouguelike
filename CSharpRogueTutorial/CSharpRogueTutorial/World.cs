using System;
using System.Collections.Generic;

namespace CSharpRogueTutorial
{
    [Serializable]
    class World
    {
        public Tile[,] Map;
        public Player Player;
        public List<GameObject> Objects;

        public World()
        {

        }
    }
}
