using mazier.Model;
using mazier.Presenter;
using mazier.View;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer; // Resolve ambiguity by explicitly aliasing Timer

namespace mazier
{
    public partial class GameForm : Form
    {
        private Player player;
        private List<Enemy> enemies;
        private List<Wall> walls;
        private Door door;
        private GamePresenter _presenter; // Declare the missing _presenter field

        public GameForm()
        {
            InitializeComponent();

            _presenter = new GamePresenter(this); // Initialize the _presenter field
            this.KeyDown += new KeyEventHandler(GameForm_KeyDown);
            Timer gameTimer = new Timer();
            gameTimer.Interval = 50;
            gameTimer.Tick += (sender, e) => _presenter.UpdateGame();
            gameTimer.Start();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            _presenter.HandleKeyPress(e.KeyCode);
        }

        public void ShowScaryForm()
        {
            // Code to display the ScaryForm
            ScaryForm scaryForm = new ScaryForm();
            scaryForm.ShowDialog();
        }

        public void ShowVictoryForm()
        {
            // Code to display the VictoryForm
            MessageBox.Show("You Win!");
        }

        public void ApplicationClosed()
        {
            // Code to handle application closure
            Application.Exit();
        }
    }
}