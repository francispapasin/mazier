using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace mazier.Model
{
    public class GameFactory
    {
        public Player CreatePlayer(PictureBox pictureBox)
        {
            return new Player(pictureBox);
        }

        public Enemy CreateEnemy(PictureBox pictureBox)
        {
            return new Enemy(pictureBox);
        }

        public Door CreateDoor(PictureBox pictureBox)
        {
            return new Door(pictureBox);
        }

        public Wall CreateWall(Panel wall) => new Wall(wall);
    }
}