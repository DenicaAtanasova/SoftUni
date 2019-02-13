using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P03_World_Count
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var wordsPath = "../../../../Resources/words.txt";
            var textPath = "../../../../Resources/text.txt";
            var resultPath = "../../../../Results/result.txt";

            var wordCount = new Dictionary<string, int>();

            using (StreamReader readerWords = new StreamReader(wordsPath))
            {
                string word;

                while ((word = readerWords.ReadLine()) != null)
                {
                    wordCount.Add(word, 0);
                }
            }

            using (StreamReader readerText = new StreamReader(textPath))
            {
                string line;

                while ((line = readerText.ReadLine()) != null)
                {
                    string pattern = @"\w+";
                    var words = Regex.Matches(line, pattern, RegexOptions.IgnoreCase);

                    foreach (Match word in words)
                    {
                        if (wordCount.ContainsKey(word.Value.ToLower()))
                        {
                            wordCount[word.Value.ToLower()]++;
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(resultPath))
            {
                foreach (var word in wordCount.Keys.OrderByDescending(x => wordCount[x]))
                {
                    writer.WriteLine($"{word} - {wordCount[word]}");
                }
            }
        }
    }
}
