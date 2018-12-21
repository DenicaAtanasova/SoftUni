using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emailList = new Dictionary<string, string>();
            string name = "";
            while ((name = Console.ReadLine()) != "stop")
            {
                string email = Console.ReadLine();
                string domain = email.Substring(email.Length - 2);
                if (domain == "bg")
                {
                    emailList[name] = email;
                }
            }
            foreach (var person in emailList)
            {
                Console.WriteLine("{0} -> {1}", person.Key, person.Value);
            }
        }
    }
}
