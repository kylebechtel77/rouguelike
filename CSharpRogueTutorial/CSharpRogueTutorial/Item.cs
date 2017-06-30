using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRogueTutorial
{
    
    class Item: GameObject
    {
        public int Weight { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public string Status { get; set; }

        public Item(char Tile, string Color, int X, int Y) : base(Tile, Color, X, Y)
        {
        }
    }
}
