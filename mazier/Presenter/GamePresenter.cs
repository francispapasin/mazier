using mazier.Model;
using mazier.View;
// Ensure the 'View' namespace exists and is correctly referenced
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer; // Ensure this is included for Timer

namespace mazier.Presenter
{
    public class GamePresenter
    {
        private readonly GameFactory _factory;
        private readonly GameForm _view;

        private Player _player;
        private List<Enemy> _enemies;
        private List<Wall> _walls;
        private List<Door> _doors;

        private bool _hasWon = false; // Track if the player has already won
        private bool _isScaryFormShown = false; // Track if the ScaryForm is already shown
        private bool _ApplicationClosed = false; // Track if the application is closed

        public GamePresenter(GameForm view)
        {
            _view = view;
            _factory = new GameFactory();
            _player = null!; // Initialize to a non-null value to satisfy the compiler
            _enemies = new List<Enemy>(); // Initialize to an empty list
            _walls = new List<Wall>(); // Initialize to an empty list
            _doors = new List<Door>(); // Initialize to an empty list
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Create Player
            _player = _factory.CreatePlayer(_view.playerPictureBox);

            // Create Enemies
            _enemies = new List<Enemy>
            {
                _factory.CreateEnemy(_view.Monster1_pictureBox),
                _factory.CreateEnemy(_view.Monster2_pictureBox),
                _factory.CreateEnemy(_view.Monster3_pictureBox),
                _factory.CreateEnemy(_view.Monster4_pictureBox),
                _factory.CreateEnemy(_view.Monster5_pictureBox),
                _factory.CreateEnemy(_view.Monster6_pictureBox),
                _factory.CreateEnemy(_view.Monster7_pictureBox)
            };

            // Create Walls
            _walls = new List<Wall>
            {
                _factory.CreateWall(_view.panel1),
                _factory.CreateWall(_view.panel2),
                _factory.CreateWall(_view.panel3),
                _factory.CreateWall(_view.panel4),
                _factory.CreateWall(_view.panel5),
                _factory.CreateWall(_view.panel6),
                _factory.CreateWall(_view.panel7),
                _factory.CreateWall(_view.panel8),
                _factory.CreateWall(_view.panel9),
                _factory.CreateWall(_view.panel10),
                _factory.CreateWall(_view.panel11),
                _factory.CreateWall(_view.panel12),
                _factory.CreateWall(_view.panel13),
                _factory.CreateWall(_view.panel14),
                _factory.CreateWall(_view.panel15),
                _factory.CreateWall(_view.panel16),
                _factory.CreateWall(_view.panel17),
                _factory.CreateWall(_view.panel18),
                _factory.CreateWall(_view.panel19),
                _factory.CreateWall(_view.panel20),
                   
                
                // Add all 20 walls
            };

            // Create Doors
            _doors = new List<Door>
            {
                _factory.CreateDoor(_view.Door1_pictureBox),
                _factory.CreateDoor(_view.Door2_pictureBox),
                _factory.CreateDoor(_view.Door3_pictureBox),
                _factory.CreateDoor(_view.Door4_pictureBox)
            };
        }

        public void HandleKeyPress(Keys key)
        {
            _player.Move(key, _walls);
        }

        public void UpdateGame()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Move(_walls);
            }

            CheckCollisions();
        }

        private void CheckCollisions()
        {
            // Check if player touches an enemy
            foreach (var enemy in _enemies)
            {
                if (_player.PlayerPictureBox.Bounds.IntersectsWith(enemy.EnemyPictureBox.Bounds) && !_isScaryFormShown)
                {
                    _isScaryFormShown = true; // Set the flag to true
                    ShowScaryForm();
                    Application.Exit();
                    break;
                }
            }

            // Check if player touches a door
            foreach (var door in _doors)
            {
                if (_player.PlayerPictureBox.Bounds.IntersectsWith(door.DoorPictureBox.Bounds) && door.IsVisible)
                {
                    if ((door == _doors[0] || door == _doors[2]) && !_hasWon) // Win doors and not already won
                    {
                        _hasWon = true; // Set the flag to true
                        ShowVictory();
                    }
                    else if (!_isScaryFormShown) // Dangerous doors
                    {
                        _isScaryFormShown = false; // Set the flag to true
                        ShowScaryForm();
                    }
                }
            }
        }

        private void ShowScaryForm()
        {
            _view.ShowScaryForm();
            _isScaryFormShown = false; // Reset the flag after the form is closed
        }

        private void ShowVictory()
        {
            _view.ShowVictoryForm();
            _hasWon = false; // Reset the flag if needed for replayability
        }
    }
}