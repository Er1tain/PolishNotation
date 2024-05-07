using PolishNotation;

namespace Program;

public class Program {

    public static void Main() {

        var convertToPN = new LeksemConvertToPN();

        Console.WriteLine("Введите название теста: ");
        string variant = Console.ReadLine();        

        try {
            //Read data from files of TestData
            using (StreamReader program = new StreamReader($"C:\\translator\\test_env\\TestData\\{variant}")) {
                string s = "";
                string line;
                while ((line = program.ReadLine()) != null) s += line;
            
                string[] S = convertToPN.Polska(s);
                
                string result = "";
                foreach (var str in S) {
                    result += str;
                }
                Console.WriteLine(result);


            }
        } catch (Exception e) {
            Console.WriteLine("Данный файл не существует!");
        } 

    }
}