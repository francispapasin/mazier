namespace mazier
{
    partial class StartForm
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
            Start = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // Start
            // 
            Start.Location = new Point(279, 238);
            Start.Name = "Start";
            Start.Size = new Size(241, 64);
            Start.TabIndex = 0;
            Start.Text = "Start Game";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // button2
            // 
            button2.Location = new Point(279, 308);
            button2.Name = "button2";
            button2.Size = new Size(241, 64);
            button2.TabIndex = 1;
            button2.Text = "Quit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(Start);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "StartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StartForm";
            ResumeLayout(false);
        }

        #endregion

        private Button Start;
        private Button button2;
    }
}