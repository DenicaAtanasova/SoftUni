using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace P06_Zipping_Sliced_Files
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var sourceFile = "../../../../Resources/sliceMe.mp4";
            var destinationDirectory = "../../../../Results/";
            int parts = 4;

            Slice(sourceFile, destinationDirectory, parts);

            var files = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                files.Add($"{destinationDirectory}/Part-{i}.gz");
            }

            Assemble(files, destinationDirectory);
        }

        public static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var size = (long)Math.Ceiling((decimal)source.Length / parts);
                byte[] buffer = new byte[size];

                for (int i = 0; i < parts; i++)
                {
                    source.Read(buffer, 0, buffer.Length);

                    var resultPath = destinationDirectory + $"Part-{i}.gz";

                    using (var result = new FileStream(resultPath, FileMode.Create))
                    {
                        using (var gz = new GZipStream(result, CompressionMode.Compress, false))
                        {
                            gz.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            var resultPath = destinationDirectory + "assembeled.mp4";

            using (var result = new FileStream(resultPath, FileMode.Create))
            {
                foreach (var file in files)
                {
                    using (var part = new FileStream(file, FileMode.Open))
                    {
                        using (var gz = new GZipStream(part, CompressionMode.Decompress, false))
                        {
                            byte[] buffer = new byte[4096];
                            int readBytes;
                            while ((readBytes = gz.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                result.Write(buffer, 0, readBytes);
                            }
                        }
                    }
                }
            }
        }
    }
}
