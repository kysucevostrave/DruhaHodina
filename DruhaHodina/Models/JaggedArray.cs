using System;
using System.Threading;


namespace DruhaHodina.Models
{
    class JaggedArray
    {
        public void Run()
        {

            bool[][] Gameboard = new bool[10][];
            for (int j = 0; j < Gameboard.Length; j++)
            {
                Gameboard[j] = new bool[10];
            }
       

            CreateTBlock(1, 1, Gameboard);
            CreateZBlock(3, 2, Gameboard);
            while (true)
            {
                MainLoop(Gameboard);
                Thread.Sleep(1000);
            }
            


            // Console.WriteLine(Gameboard.GetLength(0));
        }


        public void CreateTBlock(int x, int y, bool[][] Gameboard)
        {
            Gameboard[x][y] = true;
            Gameboard[x + 1][y] = true;
            Gameboard[x + 1][y + 1] = true;
            Gameboard[x + 2][y] = true;
        }
        public void CreateZBlock(int x, int y, bool[][] Gameboard)
        {
            Gameboard[x][y] = true;
            Gameboard[x + 1][y] = true;
            Gameboard[x + 1][y + 1] = true;
            Gameboard[x + 2][y + 1] = true;
        }

        public void MainLoop(bool[][] Gameboard)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;

            for (int i = 0; i < Gameboard.Length; i++)
            {
                for (int j = 0; j < Gameboard[i].Length; j++)
                {
                    if (Gameboard[j][i]) { 
                        Console.Write("\u2588");
                        Console.Write("\u2588");
                    }
                    else
                        Console.Write("  ");
                }
                Console.WriteLine();
            }
            MoveOneDown(Gameboard);
        }
        public void MoveOneDown(bool[][] Gameboard)
        {
            Console.WriteLine(Gameboard.Length);
            for (int i = Gameboard.Length - 1; i > 0; i--)
            {
                
                for (int j = 0; j < Gameboard[i].Length; j++)
                {
                    Gameboard[j][i] = Gameboard[j][i - 1];
                }
            }
            Gameboard[0] = new bool[Gameboard[0].Length];
        }
    }
}
