using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConfiguration.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TestClass();
            test.Test = "Freshly Created";
            test.Version = 1.0m;
           

            JConfig.Instance.Save(test);

            Console.ReadLine();
        }
    }

    public class TestClass
    {
        public string Test { get; set; }

        public decimal Version { get; set; }
    }
}
