using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class PacMan
    {
        static void Main(string[] args)
        {
            var board = new Board(3, 4);
            var console = new ConsoleWriter();

            Game theGame = new Game(board, console);
            theGame.Start();

        }
    }
}
