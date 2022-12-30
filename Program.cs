using System;
using System.Collections.Generic;

namespace RogueLikeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new player character
            Player player = new Player();

            // Set the player's starting position
            player.X = 1;
            player.Y = 1;

            // Create a new list of enemies
            List<Enemy> enemies = new List<Enemy>();

            // Add some enemies to the list
            enemies.Add(new Enemy { X = 5, Y = 5 });
            enemies.Add(new Enemy { X = 10, Y = 10 });

            // Main game loop
            while (true)
            {
                // Clear the console
                Console.Clear();

                // Draw the map
                DrawMap(player, enemies);

                // Get the player's input
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Move the player based on the input
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

                // Check if the player has collided with any enemies
                foreach (Enemy enemy in enemies)
                {
                    if (player.X == enemy.X && player.Y == enemy.Y)
                    {
                        // The player and enemy have collided, end the game
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
                        // Draw the player character
                        Console.Write("P");
                    }
                    else
                    {
                        bool enemyDrawn = false;

                        // Check if any enemies are at this position
                        foreach (Enemy enemy in enemies)
                        {
                            if (enemy.X == x && enemy.Y == y)
                            {
                                // Draw the enemy character
                                Console.Write("E");
                                enemyDrawn = true;
                                break;
                            }
                        }

                        if (!enemyDrawn)
                        {
                            // Draw an empty space
                            Console.Write(" ");
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
