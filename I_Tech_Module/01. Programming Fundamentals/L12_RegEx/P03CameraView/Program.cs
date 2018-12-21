using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03CameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int skipElements = input[0];
            int takeElements = input[1];

            string [] text = Console.ReadLine().Split('|').ToArray();

            foreach (var item in text)
            {
                if ( item != "" && item[0] == '<')
                {
                    if (item.Length > skipElements && takeElements != 0)
                    {
                        string view = item.Substring(1 + skipElements);
                        Console.Write(item == text.Last()? view : $"{view}, ");
                    }                  
                }
            }
        }
    }
}
