using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mazier.Model
{
    public class Wall
    {
        public Panel WallPanel { get; set; }

        public Wall(Panel wall)
        {
            WallPanel = wall;
        }
    }
}