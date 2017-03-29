using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grid grid = new Grid(5, 5);

            grid.SetCurrCoordinate(new Coordinate(1, 2));
            grid.SetCurrDir(Direction.North);
            
            // LMLMLMLMM
            grid.MoveCurrDir(LR.Left);
            grid.MoveOne();

            //grid.PrintCurr();

            grid.MoveCurrDir(LR.Left);
            grid.MoveOne();

            grid.MoveCurrDir(LR.Left);
            grid.MoveOne();

            grid.MoveCurrDir(LR.Left);
            grid.MoveOne();

            grid.MoveOne();

            grid.PrintCurr();

            //TODO Continue from here
            // MMRMMRMRRM   

        }
    }


    public class Coordinate
    {
        public Coordinate(int x, int y)
        {

            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("X={0}Y={1}", X, Y);
        }
    }

    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
    }

    public enum LR
    {
        Left = 0,
        Right = 1,
    }


    public class Grid
    {
        private List<Coordinate> coordinates;
        //private Char dir = 'N';
        private Coordinate currcoordinate { get; set; }
        private Direction curdir { get; set; }

        //TODO ctor sets CurrDir to Direction.North?
        public Grid(int maxX, int maxY)
        {
            coordinates = new List<Coordinate>(maxX);
            currcoordinate = new Coordinate(0, 0);
            for (int i = 0; i < maxX + 1; i++)
            {
                for (int j = 0; j < maxY + 1; j++)
                {
                    this.coordinates.Add(new Coordinate(i, j));
                }
            }
            curdir = Direction.North;
        }

        public void MoveOne()
        {
            switch (curdir)
            {
                case Direction.North:
                    currcoordinate.Y++;
                    break;
                case Direction.South:
                    currcoordinate.Y--;
                    break;
                case Direction.West:
                    currcoordinate.X--;
                    break;
                case Direction.East:
                    currcoordinate.X++;
                    break;
                default:
                    break;
            }
        }

        //public void MoveN() { CurrCoordinate.X++; }
        //public void MoveS() { CurrCoordinate.X--; }
        //public void MoveE() { CurrCoordinate.Y++; }
        //public void MoveW() { CurrCoordinate.Y--; }

        public void SetCurrDir(Direction dir)
        {
            curdir = dir;
        }

        public void SetCurrCoordinate(Coordinate c)
        {
            currcoordinate = c;
        }

        public void MoveCurrDir(LR lr)
        {

            switch (curdir)
            {
                case Direction.North:
                    curdir = (lr == LR.Right) ? Direction.East : Direction.West;
                    break;
                case Direction.South:
                    curdir = (lr == LR.Right) ? Direction.West : Direction.East;
                    break;
                case Direction.West:
                    curdir = (lr == LR.Right) ? Direction.North : Direction.South;
                    break;
                case Direction.East:
                    curdir = (lr == LR.Right) ? Direction.South : Direction.North;
                    break;

                default:
                    break;
            }
        }

        public void Print()
        {
            string s1 = "";
            coordinates.ForEach(c => s1 += c.ToString() + '\n');
            Console.WriteLine(s1);
        }

        public void PrintCurr()
        {
            Console.WriteLine("Curr:" + currcoordinate.ToString() + " Dir:" + curdir.ToString());
        }
    }

}
