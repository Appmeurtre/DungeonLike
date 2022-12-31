using System;


namespace RougeLike
{
    class Program
    {
        static void Main(string[] args)
        {
            int CharacterHealth_Current = 100;
            int CharacterHealth_Max = 100;
            int Score = 0;
            int GameOver = 0;
            int RoomCounter = 1;
            int RoomsCounted = 0;
            int RoadSteps = 1;
            int CharacterMovementUpDown = 0;
            int CharacterMovementLeftRight = 0;

            Random Random = new Random();

            string DrawCharacter = "D";
            string[,] DrawMap = new string[119, 29];
            string Direction = "";

            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 29);
                Console.Write("Health: " + CharacterHealth_Current + "/" + CharacterHealth_Max + " | Score: " + Score);

                if (RoomsCounted != RoomCounter)
                {
                    int SpawnPointHeight = Random.Next(5, 8);
                    int SpawnPointWidth = Random.Next(7, 10);
                    int SpawnPointX = Random.Next(0, 119 - SpawnPointWidth - 1);
                    int SpawnPointY = Random.Next(0, 29 - SpawnPointHeight - 1);

                    CharacterMovementLeftRight = SpawnPointX + 1;
                    CharacterMovementUpDown = SpawnPointY + 1;

                    for (int y = 0; y <= SpawnPointHeight; y++)
                    {
                        for (int x = 0; x <= SpawnPointWidth; x++)
                        {
                            if (SpawnPointX + SpawnPointWidth >= 119)
                            {
                                int X_Difference = SpawnPointX + SpawnPointWidth - 120;
                                SpawnPointX = SpawnPointX - X_Difference;
                            }

                            if (SpawnPointY + SpawnPointHeight >= 28)
                            {
                                int Y_Difference = SpawnPointY + SpawnPointHeight - 29;
                                SpawnPointY = SpawnPointY - Y_Difference;
                            }

                            if (y == 0 || y == SpawnPointHeight)
                            {
                                DrawMap[SpawnPointX + x, SpawnPointY + y] = "_";
                            }
                            else
                            {
                                if (x == 0 || x == SpawnPointWidth)
                                {
                                    DrawMap[SpawnPointX + x, SpawnPointY + y] = "|";
                                }
                                else
                                {
                                    DrawMap[SpawnPointX + x, SpawnPointY + y] = ".";
                                }
                            }
                        }
                    }
                    
                    
                    int SpawnFirstRoadRoll = Random.Next(1, 3);
                    if (SpawnFirstRoadRoll == 1)
                    {
                        int SpawnFirstRoadY = Random.Next(1, SpawnPointHeight - 1);

                        if (SpawnPointX <= 59)
                        {
                            Direction = "Right";
                            DrawMap[SpawnPointX + SpawnPointWidth, SpawnPointY + SpawnFirstRoadY + 1] = "#";
                        }

                        if (SpawnPointX > 59)
                        {
                            Direction = "Left";
                            DrawMap[SpawnPointX, SpawnPointY + SpawnFirstRoadY + 1] = "#";
                        }
                    }

                    if (SpawnFirstRoadRoll == 2)
                    {
                        int SpawnFirstRoadY = Random.Next(1, SpawnPointWidth - 1);
                        if (SpawnPointY <= 15)
                        {
                            Direction = "Down";
                            DrawMap[SpawnPointX + SpawnFirstRoadY + 1, SpawnPointY] = "#";
                        }

                        if (SpawnPointY > 15)
                        {
                            Direction = "Up";
                            DrawMap[SpawnPointX + SpawnFirstRoadY + 1, SpawnPointY] = "#";
                        }
                    }

                    RoomsCounted++;
                }

                for (int yDraw = 0; yDraw <= 28; yDraw++)
                {
                    for (int xDraw = 0; xDraw <= 118; xDraw++)
                    {
                        Console.SetCursorPosition(xDraw, yDraw);
                        Console.Write(DrawMap[xDraw, yDraw]);
                    }
                }

                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (CharacterMovementLeftRight < 118)
                        {
                            if (DrawMap[CharacterMovementLeftRight + 1, CharacterMovementUpDown] == "|" || DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown + 1] == null)
                            {
                            }
                            else
                            {
                                CharacterMovementLeftRight++;
                                DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown] = "X";
                                DrawMap[CharacterMovementLeftRight - 1, CharacterMovementUpDown] = ".";
                            }
                        }
                        else { }
                        break;

                    case ConsoleKey.LeftArrow:
                        if(CharacterMovementLeftRight > 1)
                        {
                            if (DrawMap[CharacterMovementLeftRight -1, CharacterMovementUpDown] == "|" || DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown +1] == null)
                            {

                            }
                            else
                            {
                                CharacterMovementLeftRight--;
                                DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown] = "X";
                                DrawMap[CharacterMovementLeftRight + 1, CharacterMovementUpDown] = ".";
                            }
                        }
                        else
                        {

                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (CharacterMovementUpDown > 0)
                        {
                            if (DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown - 1] == "_" || DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown + 1] == null)
                            {

                            }
                            else
                            {
                                CharacterMovementUpDown--;
                                DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown] = "X";
                                DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown + 1] = ".";
                            }
                        }
                        else
                        {

                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (CharacterMovementUpDown < 27)
                        {
                            if (DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown + 1] == "_" || DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown + 1] == null)
                            {

                            }
                            else
                            {
                                CharacterMovementUpDown++;
                                DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown] = "X";
                                DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown - 1] = ".";
                            }
                        }
                        else
                        {

                        }
                        break;
                }

                if(DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown] == "#")
                {
                    Console.SetCursorPosition(100, 29);
                    Console.Write("True");
                    RoadSteps++;

                    if (RoadSteps >= 1)
                    {
                        if (Direction == "Right")
                        {
                            DrawMap[CharacterMovementLeftRight + 1, CharacterMovementUpDown] = "#";
                        }
                        if (Direction == "Left")
                        {
                            DrawMap[CharacterMovementLeftRight - 1, CharacterMovementUpDown] = "#";
                        }
                        if (Direction == "Up")
                        {
                            DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown - 1] = "#";
                        }
                        if (Direction == "Down")
                        {
                            DrawMap[CharacterMovementLeftRight, CharacterMovementUpDown + 1] = "#";
                        }
                    }
                }

            } while (GameOver == 0);
        }
    }
}
