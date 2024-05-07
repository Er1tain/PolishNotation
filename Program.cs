using PolishNotation;

namespace Program;

public class Program {

    public static void Main() {

        var convertToPN = new LeksemConvertToPN();

        string s = "tg(x / 5 + cos(x - 5)) * (5 - x)";
        string[] S = convertToPN.Polska(s);
        
        string result = "";
        foreach (var str in S) {
            result += str;
        }
        Console.WriteLine(result);


    }
    
}