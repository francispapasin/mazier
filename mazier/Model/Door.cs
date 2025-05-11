using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace mazier.Model
{
    public class Door
    {
        public PictureBox DoorPictureBox { get; set; }
        public bool IsVisible { get; set; } = true;

        public Door(PictureBox pictureBox)
        {
            DoorPictureBox = pictureBox;
        }

        public void ToggleVisibility(bool isVisible)
        {
            DoorPictureBox.Visible = isVisible;
        }
    }
}