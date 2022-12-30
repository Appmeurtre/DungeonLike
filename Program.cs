using System;
using System.Collections.Generic;

namespace DungeonLike
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            player.X = 1;
            player.Y = 1;

            List<Enemy> enemies = new List<Enemy>();

            enemies.Add(new Enemy { X = 5, Y = 5 });
            enemies.Add(new Enemy { X = 10, Y = 10 });

            while (true)
            {

                Console.Clear();

                DrawMap(player, enemies);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        player.Y--;
                        break;
                    case ConsoleKey.DownArrow:
                        player.Y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        player.X--;
                        break;
                    case ConsoleKey.RightArrow:
                        player.X++;
                        break;
                }

                foreach (Enemy enemy in enemies)
                {
                    if (player.X == enemy.X && player.Y == enemy.Y)
                    {
                        Console.Clear();
                        Console.WriteLine("You have been defeated by the enemy!");
                        return;
                    }
                }
            }
        }

        static void DrawMap(Player player, List<Enemy> enemies)
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (player.X == x && player.Y == y)
                    {
                        Console.Write("P");
                    }
                    else
                    {
                        bool enemyDrawn = false;

                        foreach (Enemy enemy in enemies)
                        {
                            if (enemy.X == x && enemy.Y == y)
                            {
                                Console.Write("E");
                                enemyDrawn = true;
                                break;
                            }
                        }

                        if (!enemyDrawn)
                        {
                            Console.Write(".");
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }

    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
