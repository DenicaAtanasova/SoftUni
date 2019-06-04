namespace SIS.MvcFramework.Tests
{
    using System.Collections.Generic;
    using Xunit;

    public class TestViewModel
    {
        public string StringValue { get; set; }

        public IEnumerable<string> ListValues { get; set; }
    }
}