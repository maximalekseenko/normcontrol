using NormControl.Norms;


namespace NormControl.UserInterface
{
    public class InputCommand { 
        public static string lastError = "";


        public static bool isRunning = false;
        public static void Run() {
            isRunning = true;

            while (isRunning)
            {
                Render();
            }
        }


        public static void Render() {
            Renderer.Clear();


            Renderer.WriteLine("Ваши нормы:", ConsoleColor.DarkGray);

            foreach(Norm norm in Reader.ReadAll()) 
                Console.Write(norm.name + ' ');

            Renderer.WriteLine("\nВведите команду:", ConsoleColor.DarkGray);

            Renderer.Write("check ", ConsoleColor.Gray);
            Renderer.Write("<path> <name> ", ConsoleColor.Yellow);
            Renderer.Write("- проверяет документ по указанному пути <path> на соответствии норме с именем <name>\n", ConsoleColor.DarkGray);

            Renderer.Write("new ", ConsoleColor.Gray);
            Renderer.Write("<name> ", ConsoleColor.Yellow);
            Renderer.Write("- создает новую норму с именем <name> и отрывает её для редактирования\n", ConsoleColor.DarkGray);

            Renderer.Write("edit ", ConsoleColor.Gray);
            Renderer.Write("<name> ", ConsoleColor.Yellow);
            Renderer.Write("- отрывает норму с именем <name> для редактирования\n", ConsoleColor.DarkGray);

            Renderer.Write("exit ", ConsoleColor.Gray);
            Renderer.Write("- выходит из программы\n", ConsoleColor.DarkGray);


            Renderer.WriteLine(lastError, ConsoleColor.Red);

            GetCommand();
        }


        private static void GetCommand() {
            Console.Write("\n> ");
            var command = (Console.ReadLine() ?? "").Split();

            switch (command[0])
            {
                case "check":
                    if (command.Length < 3) {
                        lastError = $"Команда \"check\" требует на вход аргументы <path> и <name>.";
                        break;
                    } 
                    CheckDocument.selectedPath = command[1];

                    var norm = Reader.Read(command[2]);
                    if (norm == null) {
                        lastError = $"Норма с именем \"{command[2]}\" не найдена";
                        break;
                    }
                    CheckDocument.selectedNorm = norm;

                    CheckDocument.Run();
                break;

                case "new":
                    if (command.Length < 2) {
                        lastError = $"Команда \"new\" на вход аргумент <name>.";
                        break;
                    }
                    EditNorm.selectedNorm = new Norm(command[1]);
                    EditNorm.Run();
                break;

                case "edit":
                    if (command.Length < 2) {
                        lastError = $"Команда \"edit\" на вход аргумент <name> argument";
                        break;
                    }
                    var norm2 = Reader.Read(command[1]);
                    if (norm2 == null) {
                        lastError = $"Норма с именем \"{command[1]}\" не найдена";
                        break;
                    }
                    EditNorm.selectedNorm = norm2;
                    EditNorm.Run();
                break;

                case "exit":
                    isRunning = false;
                    Renderer.Clear();
                    Renderer.WriteLine("Бывайте.", ConsoleColor.DarkGray);
                break;
                
                default:
                    lastError = $"Команда \"{command[0]}\" не найдена";
                    break;
            }
        }
    }
}