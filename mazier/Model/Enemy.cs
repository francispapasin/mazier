using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazier.Model
{
    public class Enemy
    {
        public PictureBox EnemyPictureBox { get; set; }
        public int Speed { get; set; } = 5;

        public Enemy(PictureBox pictureBox)
        {
            EnemyPictureBox = pictureBox;
        }

        public void Move()
        {
            // Simple left to right movement
            if (EnemyPictureBox.Left + EnemyPictureBox.Width >= 500 || EnemyPictureBox.Left <= 0)
            {
                Speed = -Speed;  // Reverse direction
            }
            EnemyPictureBox.Left += Speed;
        }

        public void Move(List<Wall> walls)
        {
            var newPosition = EnemyPictureBox.Bounds;
            newPosition.X += Speed;

            // Reverse direction if colliding with walls
            if (walls.Any(wall => wall.WallPanel.Bounds.IntersectsWith(newPosition)))
            {
                Speed = -Speed;
            }
            else
            {
                EnemyPictureBox.Left += Speed;
            }
        }
    }
}