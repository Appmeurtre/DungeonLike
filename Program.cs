using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
using static System.Convert;
using static System.ConsoleColor;
using static System.ConsoleKey;
using static System.ConsoleKeyInfo;
using static System.ConsoleModifiers;
using static System.Environment;
using static System.Environment.SpecialFolder;
using static System.EnvironmentVariableTarget;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;
using static System.Globalization.NumberStyles;
using static System.Globalization.NumberFormatInfo;


namespace DungeonLike
{
    public class Program
    {
        static void main(string[] args)
        {
            int Char_health_Current = 100;
            int Char_health_Max = 100;
            int score = 0;
            int Gameover = 0;
            public Random SpawnPointGenerator = new Random();

            string[,] Draw_Game_Map = new string[239, 77]; 
            string Draw_Character = "X";

            do {
                int SpawnPointX = Random.Next(0, 230);
                int SpawnPointY = Random.Next(0, 77);
                int SpawnPointHeight = Random.Next(5, 8);
                int SpawnPointWidth = Random.Next(7, 10);

                for(int y = 0; y =< SpawnPointHeight; y++)
                {
                    for(int x = 0; x =< SpawnPointWidth; x++)
                    {
                        if(y == 0 || y == SpawnPointHeight-1)
                        {
                            
                        }
                        else 
                        {
                            
                        }
                    }
                }
            } while (Gameover == 0);
            
        }
    }
}