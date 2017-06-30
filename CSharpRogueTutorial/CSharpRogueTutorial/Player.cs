using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRogueTutorial
{
    class Player : GameObject
    {
        public List<Item> Inventory;
        public List<Item> Equipment;
        public int Health;
        public EntityStats stats;

        public Player(char Tile, string Color, int X, int Y) : base(Tile, Color, X, Y)
        {
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

        public void DeleteItem(Item item)
        {
            
        }
    }
}
