using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
 public   interface IDisplayable
    {
      void  Displayed(IWriteble wrt);
    }
}
