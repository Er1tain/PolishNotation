namespace PolishNotation;

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


        
    }
    
}