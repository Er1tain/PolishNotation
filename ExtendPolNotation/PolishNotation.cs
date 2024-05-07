namespace PolishNotation;
using System.Text.Json;

public class LeksemConvertToPN : MathP {
    
    private List<string> SystemWord = [];

    private List<string> Identificators = [];

    private List<string> Separators = [];

    private List<string> IntConsts = [];

    private List<string> DoubleConsts = [];

    private List<string> StringConsts = [];
    
    private List<string> Operations = [];

    private class Leksem {

        public int Index;
        public int text;
        public Leksem(int Index, int text) {
            this.Index = Index;
            this.text = text;
        }

    }

    public LeksemConvertToPN() {

        Dictionary<string ,List<string>> SubsetLang = new Dictionary<string, List<string>>(){
            {"SystemWord", SystemWord},
            {"Operations", Operations},
            {"Separators", Separators}
        };
        foreach (var (name, list) in SubsetLang)
            using (FileStream LeksemsJson = new FileStream($"../test_env/Leksems/{name}.json", FileMode.Open)) {

                var leksems_dict = JsonSerializer.Deserialize<Dictionary<int, string>>(LeksemsJson);
                foreach (var (key, val) in leksems_dict) {
                    list.Add(val);
                }
                // foreach(string leksem in list) Console.Write($"{leksem} ");
                // Console.WriteLine();
            }
        
    }
    
}