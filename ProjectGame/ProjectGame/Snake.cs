namespace SnakeGame
{
    class Snake : IRenderable
    {
        public List<Position> Body { get; private set; }
        public Position Head => Body.First();
        
        public Snake()
        {
            Body = new List<Position>
            {
                new Position(10, 10), 
                new Position(9, 10),
                new Position(8, 10),
                new Position(7, 10),
                new Position(6, 10)
            };
        }
        
        public void Move(Direction direction)
        {
            Position newHead = new Position(Head.X, Head.Y);
            
            switch (direction)
            {
                case Direction.Up:
                    newHead.Y--;
                    break;
                case Direction.Down:
                    newHead.Y++;
                    break;
                case Direction.Left:
                    newHead.X--;
                    break;
                case Direction.Right:
                    newHead.X++;
                    break;
            }
            
            Body.Insert(0, newHead);
            Body.RemoveAt(Body.Count - 1);
        }
        
        public void Grow()
        {
            Body.Add(new Position(Body.Last().X, Body.Last().Y));
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var pos in Body)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write("■");
            }

            Console.SetCursorPosition(Head.X, Head.Y);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("■");
        }
    }
}