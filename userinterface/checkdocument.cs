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

            XElement?  xDocumentDoc = null;
            XElement?  xStylesDoc = null;

            using (ZipArchive zip = ZipFile.Open(selectedPath, ZipArchiveMode.Read))
                foreach (ZipArchiveEntry entry in zip.Entries) {
                    if (entry.Name == "document.xml")
                        using (Stream stream = entry.Open())
                            xDocumentDoc = XElement.Load(stream);
                    if (entry.Name == "styles.xml")
                        using (Stream stream = entry.Open())
                            xStylesDoc = XElement.Load(stream);//w:
                }
            if (xDocumentDoc == null || xStylesDoc == null) { 
                isRunning = false;
                return;
            }

            // foreach(var element in xDocumentDoc.DescendantNodes().OfType<XElement>()
            //     .Where(element => element.Name == "{http://schemas.openxmlformats.org/wordprocessingml/2006/main}r"))
            // {
            //     var rpr = element.Element("{http://schemas.openxmlformats.org/wordprocessingml/2006/main}rPr");
            //     if (rpr == null) continue;
            //     foreach(var name in rpr.DescendantNodes().OfType<XElement>().Select(x => string.Join("\n", x.Attributes())).Distinct()) Console.WriteLine(name); // DEELEETEE


            //     if (!selectedNorm.styles.Any(
            //         style => {
            //             var font_familyAttr = (rpr.Element("{http://schemas.openxmlformats.org/wordprocessingml/2006/main}rFonts") ?? new XElement("")).Attribute("{http://schemas.openxmlformats.org/wordprocessingml/2006/main}ascii");
            //             if (font_familyAttr == null) return false;

            //             return style.font_family == font_familyAttr.Value;
            //         }
            //             // style.font_family == ((.Attribute()?? new XAttribute("a","a")).Value
            //     ))
            // }
            Renderer.Write("Текст не подходит формату.\n", ConsoleColor.Red);

            Renderer.Write("Чтобы вернуться введите что угодно, я не осужу.\n\n>", ConsoleColor.Gray);
            var command = Console.ReadLine();
            
            if (command == "пидор")
                Renderer.WriteLine("Сам такой", ConsoleColor.Red);

            isRunning = false;
        }
    }
}