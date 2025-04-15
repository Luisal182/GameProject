namespace SnakeGame
{
    class Food : IRenderable
    {
        public Position Position { get; private set; }
        private Random _random;
        
        public Food()
        {
            Position = new Position(0, 0);
            _random = new Random();
        }
        
        public void GenerateFood(Snake snake)
        {
            int x, y;
            bool validPosition;
            
            do
            {
                validPosition = true;
                
                x = _random.Next(2, Console.WindowWidth - 2);
                y = _random.Next(2, Console.WindowHeight - 2);
                
                foreach (var pos in snake.Body)
                {
                    if (pos.X == x && pos.Y == y)
                    {
                        validPosition = false;
                        break;
                    }
                }
                
            } while (!validPosition);
            
            Position = new Position(x, y);
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("●");
        }
    }
}