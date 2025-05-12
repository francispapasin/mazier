using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mazier
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show(); // Show the game form
            this.Hide(); // Close the application
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the application
        }
    }
}
