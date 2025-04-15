
namespace SnakeGame
{
    class Game
    {
        private Snake _snake;
        private Food _food;
        private bool _gameOver;
        private int _score;
        private int _gameSpeed = 200; 
        private GameRenderer _renderer; // Objekt to implement IRenderable
        
        public Game(Snake snake, Food food)
        {
            _snake = snake;
            _food = food;
            _gameOver = false;
            _score = 0;
            _renderer = new GameRenderer(this); // Initialice the renderer
        }
        
        // Properties to acces from other classes
        public Snake Snake => _snake;
        public Food Food => _food;
        public int Score => _score;
        public bool GameOver => _gameOver;
        
        public void Start()
        {
            _food.GenerateFood(_snake);
            
            ConsoleKeyInfo keyInfo;
            Direction currentDirection = Direction.Right;
            
            // Iniciar la lectura de teclas en un hilo separado
            Thread inputThread = new Thread(() =>
            {
                while (!_gameOver)
                {
                    if (Console.KeyAvailable)
                    {
                        keyInfo = Console.ReadKey(true);
                        
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (currentDirection != Direction.Down)
                                    currentDirection = Direction.Up;
                                break;
                            case ConsoleKey.DownArrow:
                                if (currentDirection != Direction.Up)
                                    currentDirection = Direction.Down;
                                break;
                            case ConsoleKey.LeftArrow:
                                if (currentDirection != Direction.Right)
                                    currentDirection = Direction.Left;
                                break;
                            case ConsoleKey.RightArrow:
                                if (currentDirection != Direction.Left)
                                    currentDirection = Direction.Right;
                                break;
                            case ConsoleKey.Escape:
                                _gameOver = true;
                                break;
                            case ConsoleKey.P: // Pause
                                PauseGame();
                                break;
                        }
                    }
                }
            });
            
            inputThread.IsBackground = true;
            inputThread.Start();
            
            // Principle Bucle of the game 
            while (!_gameOver)
            {
                _snake.Move(currentDirection);
                
                // Verify colision with the food
                if (_snake.Head.X == _food.Position.X && _snake.Head.Y == _food.Position.Y)
                {
                    _snake.Grow();
                    _food.GenerateFood(_snake);
                    _score += 10;
                    
                    //  speed for the game
                    if (_gameSpeed > 50)
                        _gameSpeed -= 5;
                }
                
                // Verify colision with the border or with "himself"
                if (_snake.Head.X <= 0 || _snake.Head.X >= Console.WindowWidth - 1 ||
                    _snake.Head.Y <= 0 || _snake.Head.Y >= Console.WindowHeight - 1 ||
                    _snake.Body.Skip(1).Any(b => b.X == _snake.Head.X && b.Y == _snake.Head.Y))
                {
                    _gameOver = true;
                }
                
                // Change to: Use metod draw from the renderer
                _renderer.Draw();
                
                Thread.Sleep(_gameSpeed);
            }
            
            ShowGameOverScreen();
        }

        private void PauseGame()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Juego en pausa. Presiona P para continuar");
            
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.P);
            
            // Charge again actual state of the game 
            _renderer.Draw(); //Use draw instead of Drawgame 
        }
        
        private void ShowGameOverScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 2);
            Console.WriteLine("Game Over!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2);
            Console.WriteLine($"Tu puntuación: {_score}");
            
            if (_score > 50)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 11, Console.WindowHeight / 2 + 1);
                Console.WriteLine("¡Excelente desempeño!");
            }
            
            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3);
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}