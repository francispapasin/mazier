using System.Windows.Forms;

namespace mazier.Model
{
    public class Cloud
    {
        public PictureBox CloudPictureBox { get; set; }
        public int Speed { get; set; } = 2; // Default speed
        public int Direction { get; set; } = 1; // 1 = right, -1 = left

        public Cloud(PictureBox pictureBox)
        {
            CloudPictureBox = pictureBox;
        }

        // This method is used for restricted wall collisions (e.g., only panel1 and panel2)
        public void Move(List<Wall> walls)
        {
            // Predict next position
            var newBounds = CloudPictureBox.Bounds;
            newBounds.X += Speed * Direction;

            // Check for collision with specified walls
            if (walls.Any(w => w.WallPanel.Bounds.IntersectsWith(newBounds)))
            {
                Direction = -Direction; // Reverse direction
            }
            else
            {
                CloudPictureBox.Left += Speed * Direction; // Move in current direction
            }
        }
    }
}