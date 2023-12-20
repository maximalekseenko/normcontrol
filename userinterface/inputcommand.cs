using NormControl.Norms;


namespace NormControl.UserInterface
{
    public class InputCommand { 
        public static void Render() {
            Renderer.Clear();

            Renderer.WriteColorLine(new Tuple{"asd", ConsoleColor.DarkGray});


            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Your existing norms:");
            Console.ForegroundColor = ConsoleColor.Gray;

            foreach(Norm norm in Reader.ReadAll()) 
                Console.Write(norm.name + ' ');


            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nInput your command:");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("check ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("<path> <norm> ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("- проверяет документ по указанному пути <path> на соответствии норме с именем <norm>\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("new ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("<norm> ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("- фывфывфывфыв\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("edit ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("<norm> ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("- фывфывфывфывфы\n");
            Console.ForegroundColor = ConsoleColor.Gray;


            Console.Write("\n> ");
            Console.ReadLine();
        }
    }
}