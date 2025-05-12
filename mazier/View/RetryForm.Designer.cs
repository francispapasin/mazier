
namespace mazier.View
{
    partial class RetryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Play_Again = new Button();
            button2 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // Play_Again
            // 
            Play_Again.Location = new Point(219, 326);
            Play_Again.Name = "Play_Again";
            Play_Again.Size = new Size(153, 65);
            Play_Again.TabIndex = 0;
            Play_Again.Text = "Play Again";
            Play_Again.UseVisualStyleBackColor = true;
            Play_Again.Click += Play_Again_Click;
            // 
            // button2
            // 
            button2.Location = new Point(436, 326);
            button2.Name = "button2";
            button2.Size = new Size(153, 65);
            button2.TabIndex = 1;
            button2.Text = "Quit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // RetryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.lost;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(Play_Again);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RetryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameLost";
            ResumeLayout(false);
        }

        private void Play_Again_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(); // Create a new instance of the GameForm class
            gameForm.Show(); // Show the game form
            this.Hide(); // Close the application
        }

        #endregion

        private Button Play_Again;
        private Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}