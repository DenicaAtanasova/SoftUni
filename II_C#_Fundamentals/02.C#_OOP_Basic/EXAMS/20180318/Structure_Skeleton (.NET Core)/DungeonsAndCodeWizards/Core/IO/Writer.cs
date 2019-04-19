namespace DungeonsAndCodeWizards.Core.IO
{
    using Contracts;
    using System;

    public class Writer : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
