using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Game
    {
        private IDisplayable board;
        private IWriteble console;
        public Game(IDisplayable board,IWriteble console)
        {
            this.board = board;
            this.console = console;
        }

        public void Start()
        {
            board.Displayed(console);
        }
    }
}
