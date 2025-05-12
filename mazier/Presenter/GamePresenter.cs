using mazier.Model;
using mazier.View;

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
        private List<Cloud> _clouds; // Add a list for clouds
        private bool _isRetryShown = false; // Track if the ScaryForm is already shown
        private bool _hasWon = false; // Track if the player has already won
        private bool _isScaryFormShown = false; // Track if the ScaryForm is already shown
        private GameForm2 gameForm2;
        private bool _isRetryFormShown = false;

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
                _factory.CreateWall(_view.panel21),
                _factory.CreateWall(_view.panel22), 
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

            // Create Clouds
            _clouds = new List<Cloud>
            {
                _factory.CreateCloud(_view.cloud1),
                _factory.CreateCloud(_view.cloud2),
                _factory.CreateCloud(_view.cloud3)
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

            // Restrict cloud movement collision to panel1 and panel2 only
            var restrictedCloudWalls = _walls
                .Where(w => w.WallPanel == _view.panel1 || w.WallPanel == _view.panel2)
                .ToList();

            foreach (var cloud in _clouds)
            {
                cloud.Move(restrictedCloudWalls);
            }

            CheckCollisions();
        }

        private void CheckCollisions()
        {
            // Check if player touches an enemy
            foreach (var enemy in _enemies)
            {
               

                if (_player.PlayerPictureBox.Bounds.IntersectsWith(enemy.EnemyPictureBox.Bounds) && !_isRetryShown)
                {
                    _player.TakeDamage();
                    _view.UpdateHealth(_player.Health);
                   

                    if (_player.Health <= 0)
                    {
                        _isRetryShown = true;
                        ShowRetryForm();
                      
                    }
                    else
                    {
                        ResetPlayerToStart();
                        
                    }


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
                        break;
                    }
                    else if (!_isScaryFormShown) // Dangerous doors
                    {
                        _isScaryFormShown = false; // Set the flag to true
                        ShowScaryForm();
                        break;
                    }
                }
            }
        }

        private void ResetPlayerToStart()
        {
            Point startingPoint = new Point(725, 191); // Replace with your actual player start position
            _player.PlayerPictureBox.Location = startingPoint;


        }

        private void ShowScaryForm()
        {
            _view.ShowScaryForm();
            _isScaryFormShown = true; // Reset the flag after the form is closed
            Application.Exit();
        }

        private void ShowVictory()
        {
            _view.ShowVictoryForm();
            _hasWon = false; // Reset the flag if needed for replayability
            // Exit the application after showing the victory form
        }
        private void ShowRetryForm()
        {
            _view.ShowRetryForm(); // This now shows the new form and closes the current one
            _isRetryFormShown = true;
        }

    }
}