
namespace P19TheathePhotographer
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            long picsCount = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());

            long filteredPics = (long) Math.Ceiling(picsCount * filterFactor / 100.0);
            long allPicsFilterTime = filterTime * picsCount;
            long allPicsUploadTime = uploadTime * filteredPics;

            long totalTIme = allPicsFilterTime + allPicsUploadTime;

            TimeSpan result = TimeSpan.FromSeconds(totalTIme);

            string format = result.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(format);
        }
    }
}
