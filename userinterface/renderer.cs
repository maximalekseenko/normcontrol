using NormControl.Norms;


namespace NormControl.UserInterface
{
    public class Renderer { 
        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.Gray;


        public static void Clear() {
            Console.Clear();
        }


        public static void WriteLine(string content, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ForegroundColor = DEFAULT_COLOR;
        }

        public static void Write(string content, ConsoleColor color, int line = -1, int x = -1) {
            if (line != -1) Console.SetCursorPosition(x, line);
            Console.ForegroundColor = color;
            Console.Write(content);
            Console.ForegroundColor = DEFAULT_COLOR;
        }
    }
}