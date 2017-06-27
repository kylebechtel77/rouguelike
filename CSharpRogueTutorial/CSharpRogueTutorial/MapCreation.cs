using RogueSharp;
using RogueTutorial;

namespace CSharpRogueTutorial
{
    class MapCreation
    {
        public static Map MakeMap()
        {
            Map map = new Map(Constants.MapWidth, Constants.MapHeight);

            foreach (Cell cell in map.GetAllCells())
            {
                map.SetCellProperties(cell.X, cell.Y, true, true);
            }

            map.SetCellProperties(30, 22, false, false);
            map.SetCellProperties(50, 22, false, false);

            return map;
        }
    }
}
