using System.IO;

namespace P02_Line_Numbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputPath = "../../../../Resources/text.txt";
            var outputPath = "../../../../Results/output.txt";


            using (var reader = new StreamReader(inputPath))
            {
                using (var writer = new StreamWriter(outputPath))
                {
                    var lineNumber = 1;
                    var line = string.Empty;

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {lineNumber++} {line}");
                    }
                }
            }
        }
    }
}
