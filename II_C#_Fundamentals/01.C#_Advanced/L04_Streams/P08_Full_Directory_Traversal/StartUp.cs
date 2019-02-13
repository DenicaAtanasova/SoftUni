using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace P08_Full_Directory_Traversal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var directoryInfo = new Dictionary<string, Dictionary<string, double>>();
            var files = Directory.GetFiles(".", "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var name = fileInfo.Name;
                var extension = fileInfo.Extension;
                var size = fileInfo.Length * 0.001;

                if (!directoryInfo.ContainsKey(extension))
                {
                    directoryInfo.Add(extension, new Dictionary<string, double>());
                }

                directoryInfo[extension].Add(name, size);
            }

            var resultPath = "../../../../Results/report.txt";
            //"C:/Users/Public/Desktop/report.txt";
            using (var writer = new StreamWriter(resultPath))
            {
                foreach (var ext in directoryInfo.OrderByDescending(x => x.Value.Keys.Count).ThenBy(x => x.Key))
                {
                    writer.WriteLine($"{ext.Key}");

                    foreach (var file in ext.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value:F3}kb");
                    }
                }
            }
        }
    }
}
