using System;
using System.Collections.Generic;

namespace CSharpRogueTutorial
{
    [Serializable]
    class World
    {
        public Tile[,] Map;
        public GameObject Player;
        public List<GameObject> Objects;

        public World()
        {

        }
    }
}
