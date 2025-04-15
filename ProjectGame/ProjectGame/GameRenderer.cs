

namespace SnakeGame
{
    class GameRenderer : IRenderable
    {
        private Game _game;
        
        public GameRenderer(Game game)
        {
            _game = game;
        }
        
        public void Draw()
        {
            Console.Clear();
            
            // Draw/paint borders
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write("#");
            }
            
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write("#");
            }
            
            // Draw/paint the snakes body
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var pos in _game.Snake.Body)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write("■");
            }
            
            // Draw/paint snake head
            Console.SetCursorPosition(_game.Snake.Head.X, _game.Snake.Head.Y);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("■");
            
            // Draw/paint food
            Console.SetCursorPosition(_game.Food.Position.X, _game.Food.Position.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("●");
            
            // Draw/paint points and controls
            Console.SetCursorPosition(5, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Puntuación: {_game.Score}");
            
            Console.SetCursorPosition(Console.WindowWidth - 20, 0);
            Console.Write("P = Pausa | ESC = Salir");
            
            Console.ResetColor();
        }
    }
}