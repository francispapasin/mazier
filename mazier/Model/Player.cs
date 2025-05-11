using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace mazier.Model
{
    public class Player
    {
        public PictureBox PlayerPictureBox { get; set; }
        public int Speed { get; set; } = 10;

        public Player(PictureBox pictureBox)
        {
            PlayerPictureBox = pictureBox;
        }

        public void Move(Keys direction, List<Wall> walls)
        {
            var newPosition = PlayerPictureBox.Bounds;

            switch (direction)
            {
                case Keys.W:
                    newPosition.Y -= Speed;
                    break;
                case Keys.S:
                    newPosition.Y += Speed;
                    break;
                case Keys.A:
                    newPosition.X -= Speed;
                    break;
                case Keys.D:
                    newPosition.X += Speed;
                    break;
            }

            // Check for collisions with walls
            if (!walls.Any(wall => wall.WallPanel.Bounds.IntersectsWith(newPosition)))
            {
                PlayerPictureBox.Bounds = newPosition;
            }
        }

        public void ResetPosition(Point startPosition)
        {
            PlayerPictureBox.Location = startPosition;
        }
    }
}