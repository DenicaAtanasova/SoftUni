﻿namespace DungeonsAndCodeWizards.Core.IO
{
    using Contracts;
    using System;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
