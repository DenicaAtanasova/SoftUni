using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = "";
            int quantity = 0;

            Dictionary<string, int> resourceQuantity = new Dictionary<string, int>();

            while ((resource = Console.ReadLine()) != "stop")
            {
                quantity = int.Parse(Console.ReadLine());
                if (resourceQuantity.ContainsKey(resource))
                {
                    resourceQuantity[resource] += quantity;
                }
                else
                {
                    resourceQuantity[resource] = quantity;
                }                             
            }
            foreach (KeyValuePair<string, int> pair in resourceQuantity)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}