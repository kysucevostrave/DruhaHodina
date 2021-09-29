using System;
using System.Threading;

namespace DruhaHodina.Models
{
    struct Brick
    {
        public int x;
        public int y;
        public bool val;
        public Brick(int _x, int _y, bool _val)
        {
            this.x = _x;
            this.y = _y;
            this.val = _val;
        }
    }

    struct CompositeBrick
    {
        public int x;
        public int y;
        public Brick[] compositeBrick;

        public CompositeBrick(int x, int y, Brick[] compositeBrick)
        {
            this.x = x;
            this.y = y;
            this.compositeBrick = compositeBrick;
        }

        public void FillCompositeBrick(CompositeBrick[] Gameboard)
        {
            for (int i = 0; i < this.compositeBrick.Length; i++)
            {
                int _x = this.compositeBrick[i].x;
                int _y = this.compositeBrick[i].y;
                if(_x < Gameboard.Length)
                    Gameboard[_x].compositeBrick[_y].val = true;
            }
        }
    }

    class StructureArray
    {
        
        public void Run()
        {
            CompositeBrick[] Gameboard = new CompositeBrick[10];
            for (int i = 0; i < Gameboard.Length; i++)
            {
                Gameboard[i] = new CompositeBrick(i, 0, new Brick[20]);
                for (int j = 0; j < Gameboard[i].compositeBrick.Length; j++)
                {
                    Gameboard[i].compositeBrick[j] = new Brick(i,j,false);
                }
            }

            CompositeBrick TBlock = CreateTBlock(1, 1, Gameboard);
            CompositeBrick TBlock2 = CreateTBlock(5, 10, Gameboard);
         
            CompositeBrick ZBlock = CreateZBlock(3, 3, Gameboard);
            CompositeBrick ZBlock2 = CreateZBlock(2, 8, Gameboard);
    

            while (true)
            {
                MainLoop(Gameboard, TBlock, ZBlock, TBlock2, ZBlock2);
                Thread.Sleep(1000);
            }

        }

        public CompositeBrick CreateTBlock(int x, int y, CompositeBrick[] Gameboard)
        {
            Brick[] BricksArr = new Brick[] { 
                Gameboard[x].compositeBrick[y], Gameboard[x].compositeBrick[y + 1], 
                Gameboard[x + 1].compositeBrick[y + 1], Gameboard[x].compositeBrick[y + 2] 
            };
            CompositeBrick _TBlock = new(x, y, BricksArr);
            _TBlock.FillCompositeBrick(Gameboard);
            return _TBlock;
        }
        public CompositeBrick CreateZBlock(int x, int y, CompositeBrick[] Gameboard)
        {
            Brick[] BricksArr = new Brick[] {
                Gameboard[x].compositeBrick[y], Gameboard[x].compositeBrick[y + 1],
                Gameboard[x + 1].compositeBrick[y + 1], Gameboard[x + 1].compositeBrick[y + 2]
            };
            CompositeBrick _ZBlock = new(x, y, BricksArr);
            _ZBlock.FillCompositeBrick(Gameboard);
            return _ZBlock;
        }

       
        public void MainLoop(CompositeBrick[] Gameboard, params CompositeBrick[] Blocks)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;


            for (int i = 0; i < Gameboard.Length; i++)
            {
                for (int j = 0; j < Gameboard[i].compositeBrick.Length; j++)
                {
                    if (Gameboard[i].compositeBrick[j].val) { 
                        Console.Write("\u2588");
                        Console.Write("\u2588");
                    }
                    else
                        Console.Write("  ");
                }
                Console.WriteLine();
            }

            foreach (var item in Blocks)
            {
                MoveDown(Gameboard, item);
            }
        }
        public void MoveDown(CompositeBrick[] Gameboard, CompositeBrick Shape)
        {
            Shape.x += 1;
            for (int i = 0; i < Shape.compositeBrick.Length; i++)
            {
                int _x = Shape.compositeBrick[i].x;
                int _y = Shape.compositeBrick[i].y;
                if (_x < Gameboard.Length)
                {
                    Gameboard[_x].compositeBrick[_y].val = false;
                }
                Shape.compositeBrick[i].x++;

            }
            Shape.FillCompositeBrick(Gameboard);
        }

    }
}
