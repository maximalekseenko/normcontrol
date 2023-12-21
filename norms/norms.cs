
namespace NormControl.Norms
{
    public class Norm { 
        public string name {get; set;}
        public Style[] styles {get; set;} = new Style[6] {
            new(12), new(12), new(36), 
            new(24), new(18), new(20), 
        };
        public Norm(string name) {
            this.name = name;
        }
    }
}