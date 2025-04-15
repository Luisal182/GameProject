namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Snake Game";
            Console.CursorVisible = false;
            
            ShowIntroScreen();
            
            Snake snake = new Snake();
            Food food = new Food();
            Game game = new Game(snake, food);
            game.Start();
        } 
        
        static void ShowIntroScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            Console.SetCursorPosition(width / 2 - 6, height / 2 - 1);
            Console.WriteLine("¡Bienvenido al Snake!");
            Console.SetCursorPosition(width / 2 - 15, height / 2);
            Console.WriteLine("Usa las flechas para moverte.");
            Console.SetCursorPosition(width / 2 - 12, height / 2 + 1);
            Console.WriteLine("Presiona cualquier tecla para comenzar...");
            
            Console.ReadKey();
        }
    }
}