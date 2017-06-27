using RogueSharp;
using RogueTutorial;

namespace CSharpRogueTutorial
{
    class MapCreation
    {
        public static void MakeMap()
        {
            Rogue.map = new Map(Constants.MapWidth, Constants.MapHeight);

            foreach (Cell cell in Rogue.map.GetAllCells())
            {
                Rogue.map.SetCellProperties(cell.X, cell.Y, true, true);
            }

            Rogue.map.SetCellProperties(30, 22, false, false);
            Rogue.map.SetCellProperties(50, 22, false, false);
        }
    }
}
