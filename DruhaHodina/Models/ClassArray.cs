
using System;
using System.Threading;

namespace DruhaHodina.Models
{
    public class BrickClass
    {
        public int x;
        public int y;
        public bool val;
        public BrickClass(int _x, int _y, bool _val)
        {
            this.x = _x;
            this.y = _y;
            this.val = _val;
        }
    }

    public class CompositeBrickClass
    {
        public int x;
        public int y;
        public BrickClass[] compositeBrick;

        public CompositeBrickClass(int x, int y, BrickClass[] compositeBrick)
        {
            this.x = x;
            this.y = y;
            this.compositeBrick = compositeBrick;
        }

        public void FillCompositeBrickClass(CompositeBrickClass[] Gameboard)
        {
            for (int i = 0; i < this.compositeBrick.Length; i++)
            {
                //this.compositeBrick[i].val = true;
                if(this.compositeBrick[i].x < Gameboard.Length) { 
                    Gameboard[this.compositeBrick[i].x].compositeBrick[this.compositeBrick[i].y].val = true;
                }
            }
        }
        public void EmptyCompositeBrickClass(CompositeBrickClass[] Gameboard)
        {
            for (int i = 0; i < this.compositeBrick.Length; i++)
            {
                //this.compositeBrick[i].val = false;
                if (this.compositeBrick[i].x < Gameboard.Length)
                {
                    Gameboard[this.compositeBrick[i].x].compositeBrick[this.compositeBrick[i].y].val = false;
                }
            }
        }
    }

    class ClassArray
    {

        public void Run()
        {

            CompositeBrickClass[] Gameboard = new CompositeBrickClass[10];
            for (int i = 0; i < Gameboard.Length; i++)
            {
                Gameboard[i] = new CompositeBrickClass(i, 0, new BrickClass[20]);
                for (int j = 0; j < Gameboard[i].compositeBrick.Length; j++)
                {
                    Gameboard[i].compositeBrick[j] = new BrickClass(i, j, false);
                }
            }

            CompositeBrickClass TBlock = CreateTBlockClass(1, 1,Gameboard);
            CompositeBrickClass TBlock2 = CreateTBlockClass(5, 10,Gameboard);

            CompositeBrickClass ZBlock = CreateZBlockClass(3, 3, Gameboard);
            CompositeBrickClass ZBlock2 = CreateZBlockClass(2, 8, Gameboard);


            while (true)
            {
                MainLoop(Gameboard, TBlock, ZBlock, TBlock2, ZBlock2);
                Thread.Sleep(1000);
            }


        }

        public CompositeBrickClass CreateTBlockClass(int x, int y,CompositeBrickClass[] Gameboard)
        {
            BrickClass[] BricksArr = new BrickClass[] {
                new BrickClass(Gameboard[x].compositeBrick[y].x,Gameboard[x].compositeBrick[y].y,false),
                new BrickClass(Gameboard[x].compositeBrick[y + 1].x,Gameboard[x].compositeBrick[y + 1].y,false),
                new BrickClass(Gameboard[x + 1].compositeBrick[y + 1].x,Gameboard[x + 1].compositeBrick[y + 1].y,false),
                new BrickClass(Gameboard[x].compositeBrick[y + 2].x,Gameboard[x].compositeBrick[y + 2].y,false)
            };

            CompositeBrickClass _TBlock = new(x, y, BricksArr);


            _TBlock.FillCompositeBrickClass(Gameboard);
            return _TBlock;
        }
        public CompositeBrickClass CreateZBlockClass(int x, int y,CompositeBrickClass[] Gameboard)
        {
            BrickClass[] BricksArr = new BrickClass[] {
                new BrickClass(Gameboard[x].compositeBrick[y].x,Gameboard[x].compositeBrick[y].y,false),
                new BrickClass(Gameboard[x].compositeBrick[y + 1].x,Gameboard[x].compositeBrick[y + 1].y,false),
                new BrickClass(Gameboard[x + 1].compositeBrick[y + 1].x,Gameboard[x + 1].compositeBrick[y + 1].y,false),
                new BrickClass(Gameboard[x+1].compositeBrick[y + 2].x,Gameboard[x+1].compositeBrick[y + 2].y,false)
            };
            CompositeBrickClass _ZBlock = new(x, y, BricksArr);
            _ZBlock.FillCompositeBrickClass(Gameboard);
            return _ZBlock;
        }


        public void MainLoop(CompositeBrickClass[] Gameboard, params CompositeBrickClass[] Blocks)
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
            
             foreach (var Shape in Blocks)
            {
                MoveDown(Gameboard,Shape);
            }
         
        }
        public void MoveDown(CompositeBrickClass[] Gameboard, CompositeBrickClass Shape)
        {
            Shape.EmptyCompositeBrickClass(Gameboard);
            //Shape.x ++;
            
            for (int i = 0; i < Shape.compositeBrick.Length; i++)
            {
                /*int my_x = Shape.compositeBrick[i].x;
      
                if(my_x < Gameboard.Length-1) {*/
                    Shape.compositeBrick[i].x = Shape.compositeBrick[i].x + 1;
                
                
            }
            /*Gameboard[Shape.compositeBrick[0].x].compositeBrick[Shape.compositeBrick[0].y].val = false;
            Gameboard[Shape.compositeBrick[0].x+1].compositeBrick[Shape.compositeBrick[0].y].val = true;
            Gameboard[Shape.compositeBrick[1].x].compositeBrick[Shape.compositeBrick[1].y].val = false;
            Gameboard[Shape.compositeBrick[1].x + 1].compositeBrick[Shape.compositeBrick[1].y].val = true;
            Gameboard[Shape.compositeBrick[2].x].compositeBrick[Shape.compositeBrick[2].y].val = false;
            Gameboard[Shape.compositeBrick[2].x + 1].compositeBrick[Shape.compositeBrick[2].y].val = true;
            Gameboard[Shape.compositeBrick[3].x].compositeBrick[Shape.compositeBrick[3].y].val = false;
            Gameboard[Shape.compositeBrick[3].x + 1].compositeBrick[Shape.compositeBrick[3].y].val = true;*/


            Shape.FillCompositeBrickClass(Gameboard);
        }
    }
}
