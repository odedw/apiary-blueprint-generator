using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiaryBlueprintGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                PrintUsage();
            }
            else
            {
                Parser parser = new Parser(args[0], args.Length > 2 ? args[2] : "");
                parser.Parse();
            }
            Console.ReadKey();
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: ApiaryBlueprintGenerator [input-file] [output-file] [namespace-prefix:optional]");
        }
    }
}
