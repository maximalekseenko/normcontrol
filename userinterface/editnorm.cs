using NormControl.Norms;


namespace NormControl.UserInterface
{
    public class EditNorm { 

        private const int SECOND_COL_X = 50;
        public static Norm selectedNorm = new Norm("");
        public static string lastError = "";


        public static bool isRunning = false;
        public static void Run() {
            isRunning = true;
            lastError = "";

            while (isRunning)
            {
                Render();
            }
        }

        public static void Render() {
            Renderer.Clear();


            Renderer.Write($"Редактирование нормы ", ConsoleColor.Gray);
            Renderer.Write($"\"{selectedNorm.name}\"\n", ConsoleColor.Yellow);

            Renderer.Write("\nnormal - ", ConsoleColor.DarkGray);
            Renderer.Write("Нормальный текст\n", ConsoleColor.Yellow);
            Renderer.Write("font_family\t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[0].font_family + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("font_size  \t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[0].font_size + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_bold    \t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[0].is_bold.ToString() + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_italic  \t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[0].is_italic.ToString() + "\n", ConsoleColor.DarkYellow);

            Renderer.Write("\nquote - ", ConsoleColor.DarkGray);
            Renderer.Write("Цитата\n", ConsoleColor.Yellow);
            Renderer.Write("font_family\t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[1].font_family + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("font_size  \t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[1].font_size + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_bold    \t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[1].is_bold.ToString() + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_italic  \t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[1].is_italic.ToString() + "\n", ConsoleColor.DarkYellow);

            Renderer.Write("\ntitle - ", ConsoleColor.DarkGray);
            Renderer.Write("Титульный Заголовок\n", ConsoleColor.Yellow);
            Renderer.Write("font_family\t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[2].font_family + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("font_size  \t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[2].font_size + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_bold    \t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[2].is_bold.ToString() + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_italic  \t", ConsoleColor.Gray);
            Renderer.Write(selectedNorm.styles[2].is_italic.ToString() + "\n", ConsoleColor.DarkYellow);

            Renderer.Write("header1 - ", ConsoleColor.DarkGray, 2, SECOND_COL_X);
            Renderer.Write("Заголовок 1\n", ConsoleColor.Yellow);
            Renderer.Write("font_family\t", ConsoleColor.Gray, 3, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[3].font_family + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("font_size  \t", ConsoleColor.Gray, 4, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[3].font_size + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_bold    \t", ConsoleColor.Gray, 5, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[3].is_bold.ToString() + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_italic  \t", ConsoleColor.Gray, 6, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[3].is_italic.ToString() + "\n", ConsoleColor.DarkYellow);

            Renderer.Write("header2 - ", ConsoleColor.DarkGray, 8, SECOND_COL_X);
            Renderer.Write("Заголовок 2\n", ConsoleColor.Yellow);
            Renderer.Write("font_family\t", ConsoleColor.Gray, 9, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[4].font_family + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("font_size  \t", ConsoleColor.Gray, 10, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[4].font_size + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_bold    \t", ConsoleColor.Gray, 11, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[4].is_bold.ToString() + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_italic  \t", ConsoleColor.Gray, 12, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[4].is_italic.ToString() + "\n", ConsoleColor.DarkYellow);

            Renderer.Write("header3 - ", ConsoleColor.DarkGray, 14, SECOND_COL_X);
            Renderer.Write("Заголовок 3\n", ConsoleColor.Yellow);
            Renderer.Write("font_family\t", ConsoleColor.Gray, 15, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[5].font_family + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("font_size  \t", ConsoleColor.Gray, 16, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[5].font_size + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_bold    \t", ConsoleColor.Gray, 17, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[5].is_bold.ToString() + "\n", ConsoleColor.DarkYellow);
            Renderer.Write("is_italic  \t", ConsoleColor.Gray, 18, SECOND_COL_X);
            Renderer.Write(selectedNorm.styles[5].is_italic.ToString() + "\n", ConsoleColor.DarkYellow);


            Renderer.Write("\nДля редактирования введите параметр и его новое значение\n", ConsoleColor.Gray);
            Renderer.Write("Пример: header2 font_size 42\n", ConsoleColor.DarkGray);
            Renderer.Write("Для окончания редактирования введите \"save\" или \"cancel\"\n", ConsoleColor.Gray);
            Renderer.Write("Для удаления введите delete\n\n", ConsoleColor.Gray);

            Renderer.WriteLine(lastError, ConsoleColor.Red);

            GetCommand();
        }


        private static void GetCommand() {
            Console.Write("\n> ");
            var command = (Console.ReadLine() ?? "").Split();

            if (command[0] == "save") {
                Reader.Write(selectedNorm);
                isRunning = false;
                return;
            }
            if (command[0] == "cancel") {
                isRunning = false;
                return;
            }
            else if (command[0] == "delete") {
                Reader.Delete(selectedNorm.name);
                isRunning = false;
                return;
            }

            if (command.Length != 3) {
                return; 
            }

            int selectedStyleIndex;
            if (command[0] == "normal") selectedStyleIndex = 0;
            else if (command[0] == "quote") selectedStyleIndex = 1;
            else if (command[0] == "title") selectedStyleIndex = 2;
            else if (command[0] == "header1") selectedStyleIndex = 3;
            else if (command[0] == "header2") selectedStyleIndex = 4;
            else if (command[0] == "header3") selectedStyleIndex = 5;
            else {
                lastError = $"Стиль для \"{command[0]}\" не найден.";
                return;
            }
            

            if (command[1] == "font_family") {
                selectedNorm.styles[selectedStyleIndex].font_family = command[2];
            }
            else if (command[1] == "font_size") {
                try {
                    selectedNorm.styles[selectedStyleIndex].font_size = int.Parse(command[2]);
                } catch {
                    lastError = $"Значение \"{command[2]}\" должно быть числом.";
                }
            }
            else if (command[1] == "is_bold") {
                if (command[2].ToLower() == "true") 
                    selectedNorm.styles[selectedStyleIndex].is_bold = true;
                else if (command[2].ToLower() == "false")
                    selectedNorm.styles[selectedStyleIndex].is_bold = false;
                else lastError = $"Значение \"{command[2]}\" должно быть \"True\" или \"False\".";
            }
            else if (command[1] == "is_italic") {
                if (command[2].ToLower() == "true") 
                    selectedNorm.styles[selectedStyleIndex].is_bold = true;
                else if (command[2].ToLower() == "false")
                    selectedNorm.styles[selectedStyleIndex].is_bold = false;
                else lastError = $"Значение \"{command[2]}\" должно быть \"True\" или \"False\".";
            } 
            else {
                lastError = $"Параметр \"{command[1]}\" не найден.";
                return;
            }
        }
    }
}