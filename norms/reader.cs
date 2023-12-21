using System.IO;
using System.Text.Json;


namespace NormControl.Norms
{
    public class Reader { 
        public static Norm? Read(string name) {
            var normList = ReadAll();
            Norm? foundNorm = null;

            foreach (var norm in normList)
                if (norm.name == name)
                    foundNorm = norm;

            return foundNorm;
        }

        public static void Write(Norm norm) {
            var normList = ReadAll();

            for (int i = 0; i < normList.Count; i++)
                if (normList[i].name == norm.name) {
                    normList.RemoveAt(i);
                    break;
                }

            normList.Add(norm);
            File.WriteAllText(@"./mynorms.js", JsonSerializer.Serialize(normList));
        }

        public static void Delete(string name) {
            var normList = ReadAll();
            
            for (int i = 0; i < normList.Count; i++)
                if (normList[i].name == name) {
                    normList.RemoveAt(i);
                    break;
                }

            File.WriteAllText(@"./mynorms.js", JsonSerializer.Serialize(normList));
        }

        
        public static List<Norm> ReadAll() {
            if (!File.Exists(@"./mynorms.js")) return new List<Norm>();
            var text = File.ReadAllText(@"./mynorms.js");
            if (text == null) return new List<Norm>();
            var normList = JsonSerializer.Deserialize<List<Norm>>(text);
            if (normList == null) return new List<Norm>();
            return normList;
        }
    }
}