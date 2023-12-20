using NormControl.Norms;


namespace NormControl.UserInterface
{
    public class Renderer { 
        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.Gray;


        public static void Clear() {
            Console.Clear();
        }


        public static void WriteColorLine(List<Tuple<string, ConsoleColor>> lines) {

            foreach (var line in lines) {
                Console.ForegroundColor = line.Item2;
                Console.WriteLine(line.Item1);
            }

            // return to default
            Console.ForegroundColor = DEFAULT_COLOR;
        }
    }
}