using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class ConsoleWriter : IWriteble
    {
        public void Write(string str)
        {
            Console.Write(str);
        }
        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
