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
        private Timer _gameTimer;

        public GameForm()
        {
            InitializeComponent();

            // Initialize the player, enemies, walls, and door
            this.DoubleBuffered = true;

            _presenter = new GamePresenter(this); // Initialize the _presenter field
            this.KeyDown += new KeyEventHandler(GameForm_KeyDown);
        }

        private void InitializeGameTimer()
        {
            _gameTimer = new Timer();
            _gameTimer.Interval = 16; // Approximately 60 FPS
            _gameTimer.Tick += (sender, e) => _presenter.UpdateGame();
            _gameTimer.Start();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeGameTimer();
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
            Application.Exit();
        }

        public void ShowVictoryForm()
        {
            Gamewin gamewin = new Gamewin();
            gamewin.ShowDialog();
            Application.Exit();

        }

        public void ShowRetryForm()
        {
            this.BeginInvoke(new Action(() =>
            {
                var retryForm = new RetryForm(); // Or whatever your retry/game over form is called
                retryForm.Show();
                this.Hide();
            }));
        }

        public void ApplicationExit()
        {
            this.Close(); // Close the current form
        }


        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        public void UpdateHealth(int currentHealth)
        {
            healthLabel1.Text = $"Lives: {currentHealth}";

            if (currentHealth == 1)
                healthLabel1.ForeColor = Color.Red;
            else if (currentHealth == 2)
                healthLabel1.ForeColor = Color.Orange;
            else
                healthLabel1.ForeColor = Color.Green;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            var startForm = new StartForm();
            startForm.Show();
        }
    }
}