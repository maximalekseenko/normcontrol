using NormControl.Norms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.IO.Compression;


namespace NormControl.UserInterface
{
    public class CheckDocument { 
        public static Norm selectedNorm = new Norm("");
        public static string selectedPath = "";
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
            
            List<int> Mistakes = new List<int>();

            XmlDocument xDoc = new XmlDocument();

            using (ZipArchive zip = ZipFile.Open(selectedPath, ZipArchiveMode.Read))
                foreach (ZipArchiveEntry entry in zip.Entries)
                    if (entry.Name == "document.xml")
                        using (Stream stream = entry.Open())
                            xDoc.Load(stream);

            Renderer.WriteLine(xDoc.DocumentElement.Name, ConsoleColor.Magenta);

            Renderer.Write("Чтобы вернуться введите что угодно, я не осужу.\n\n>", ConsoleColor.Gray);
            var command = Console.ReadLine();
            
            if (command == "пидор")
                Renderer.WriteLine("Сам такой", ConsoleColor.Red);

            isRunning = false;
        }
    }
}