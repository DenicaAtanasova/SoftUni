using System.IO;

namespace P04_Copy_Binary_File
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var sourcePath = "../../../../Resources/copyMe.png";
            var resultPath = "../../../../Results/result.png";

            using (var source = new FileStream(sourcePath, FileMode.Open))
            {
                var size = source.Length;
                var buffer = new byte[size];

                source.Read(buffer, 0, buffer.Length);

                using (var result = new FileStream(resultPath, FileMode.Create))
                {
                    result.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
