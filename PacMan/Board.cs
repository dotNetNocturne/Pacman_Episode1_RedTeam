using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public enum Orientation
    {
        Up, Down, Left, Right
    }


    public class Board : IDisplayable
    {
        private int Columns { get; set; }
        private int Rows { get; set; }


        public Board(int width, int height)
        {
            Columns = width;
            Rows = height;

            PacmanPosition = new Position(Columns / 2, Rows / 2);
        }


        public Position PacmanPosition { get; private set; }

        public Orientation PacmanOrientation { get; private set; }

        public void Turn(Orientation orientation)
        {
            PacmanOrientation = orientation;
        }

        public void Tick()
        {
            switch (PacmanOrientation)
            {
                case Orientation.Up:
                    {
                        PacmanPosition = new Position(PacmanPosition.X, PacmanPosition.Y == 0 ? this.Rows - 1 : PacmanPosition.Y - 1);
                    } break;
                case Orientation.Down:
                    {
                        PacmanPosition = new Position(PacmanPosition.X, (PacmanPosition.Y + 1) % Rows);
                    }
                    break;
                case Orientation.Left:
                    {
                        PacmanPosition = new Position(PacmanPosition.X == 0 ? this.Columns - 1 : PacmanPosition.X - 1, PacmanPosition.Y);
                    } break;
                case Orientation.Right:
                    {
                        PacmanPosition = new Position((PacmanPosition.X + 1) % Columns, PacmanPosition.Y);
                    } break;

            }
        }

        public void Displayed(IWriteble wrt)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (new Position(col, row).Equals(PacmanPosition))
                    {
                        wrt.Write("v ");
                    }
                    else
                        wrt.Write(". ");
                }
                wrt.WriteLine();
            }
        }
    }

    public struct Position
    {
        private int x;
        private int y;
        public int X { get; private set; }
        public int Y { get; private set; }
        public Position(int col, int row)
            : this()
        {
            X = col;
            Y = row;
        }


        public override string ToString()
        {
            return X + "," + Y;
        }
    }
}
