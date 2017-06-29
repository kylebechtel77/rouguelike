using RogueTutorial;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpRogueTutorial
{
    [Serializable]
    class Tile
    {
        public bool blocked;
        public bool explored;
        public bool visited;

        public Tile(bool Blocked)
        {
            blocked = Blocked;
            explored = false;
            visited = false;
        }
    }

    class Point
    {
        public int x;
        public int y;

        public Point(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }

    class Room
    {
        public int startX;
        public int startY;
        public int endX;
        public int endY;

        public Room(int X, int Y, int Width, int Height)
        {
            startX = X;
            startY = Y;
            endX = X + Width;
            endY = Y + Height;
        }

        internal Point Center()
        {
            int centerX = (startX + endX) / 2;
            int centerY = (startY + endY) / 2;

            return new Point(centerX, centerY);
        }

        internal bool Intersect(Room otherRoom)
        {
            return (startX <= otherRoom.endX && endX >= otherRoom.startX && startY <= otherRoom.endY && endY >= otherRoom.startY);
        }
    }

    class MapCreation
    {
        public static Random rand = new Random();

        public static Tile[,] MakeMap()
        {
            Tile[,] map = BlankMap(true);

            List<Room> roomList = new List<Room>();

            int roomCount = 0;

            for (int i = 0; i < 20; i++)
            {
                int width = rand.Next(5, 8);
                int height = rand.Next(5, 8);

                int x = rand.Next(0, Constants.MapWidth - width - 1);
                int y = rand.Next(0, Constants.MapHeight - height - 1);

                Room newRoom = new Room(x, y, width, height);

                bool failed = false;
                foreach (Room otherRoom in roomList)
                {
                    if (newRoom.Intersect(otherRoom))
                    {
                        failed = true;
                        break;
                    }
                }

                if (!failed)
                {
                    CreateRoom(newRoom, ref map);

                    Point newCenter = newRoom.Center();

                    if (roomCount == 0)
                    {
                        Rogue.GameWorld.Player.x = newCenter.x;
                        Rogue.GameWorld.Player.y = newCenter.y;
                    }
                    else
                    {
                        Point previousCenter = roomList[roomCount - 1].Center();

                        if (rand.Next(0, 2) == 0)
                        {
                            CreateHorizontalTunnel(previousCenter.x, newCenter.x, previousCenter.y, ref map);
                            CreateVerticalTunnel(previousCenter.y, newCenter.y, newCenter.x, ref map);
                        }
                        else
                        {
                            CreateVerticalTunnel(previousCenter.y, newCenter.y, previousCenter.x, ref map);
                            CreateHorizontalTunnel(previousCenter.x, newCenter.x, newCenter.y, ref map);
                        }
                    }

                    roomList.Add(newRoom);
                    roomCount += 1;
                }
            }

            return map;
        }

        private static void CreateRoom(Room room, ref Tile[,] map)
        {
            for (int x = room.startX + 1; x < room.endX; x++)
            {
                for (int y = room.startY + 1; y < room.endY; y++)
                {
                    map[x, y].blocked = false;
                }
            }
        }

        private static void CreateHorizontalTunnel(int x1, int x2, int y, ref Tile[,] map)
        {
            for (int x = Math.Min(x1, x2); x < Math.Max(x1, x2) + 1; x++)
            {
                map[x, y].blocked = false;
            }
        }

        private static void CreateVerticalTunnel(int y1, int y2, int x, ref Tile[,] map)
        {
            for (int y = Math.Min(y1, y2); y < Math.Max(y1, y2) + 1; y++)
            {
                map[x, y].blocked = false;
            }
        }

        private static Tile[,] BlankMap(bool Blocked)
        {
            Tile[,] map = new Tile[Constants.MapWidth, Constants.MapHeight];

            for (int x = 0; x < Constants.MapWidth; x++)
            {
                for (int y = 0; y < Constants.MapHeight; y++)
                {
                    map[x, y] = new Tile(Blocked);
                }
            }

            return map;
        }

        public static Tile[,] MakeMaze()
        {
            Tile[,] map = BlankMap(true);

            for (int x = 0; x < Constants.MapWidth - 1; x++)
            {
                for (int y = 0; y < Constants.MapHeight - 1; y++)
                {
                    if (x % 2 != 0 && y % 2 != 0)
                    {
                        map[x, y] = new Tile(false);
                    }
                }
            }

            CarveMaze(1, 1, ref map);

            Rogue.GameWorld.Player.x = 1;
            Rogue.GameWorld.Player.y = 1;

            return map;
        }

        public static void CarveMaze(int startx, int starty, ref Tile[,] map)
        {
            map[startx, starty].visited = true;

            foreach (Point tile in GetMazeNeighbours(startx, starty))
            {
                if (map[tile.x, tile.y].visited == false)
                {
                    map[(tile.x + startx) / 2, (tile.y + starty) / 2].blocked = false;

                    CarveMaze(tile.x, tile.y, ref map);
                }
            }
        }

        public static List<Point> GetMazeNeighbours(int x, int y)
        {
            List<Point> neighbours = new List<Point>();

            if (x - 2 >= 0) neighbours.Add(new Point(x - 2, y));
            if (x + 2 <= Constants.MapWidth - 2) neighbours.Add(new Point(x + 2, y));
            if (y - 2 >= 0) neighbours.Add(new Point(x, y - 2));
            if (y + 2 <= Constants.MapHeight - 2) neighbours.Add(new Point(x, y + 2));

            return neighbours.OrderBy(a => rand.Next()).ToList();
        }
    }
}
