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
            if (args.Length < 3)
            {
                PrintUsage();
            }
            else
            {
                Parser parser = new Parser(args[0], args.Length > 2 ? args[2] : string.Empty, args.Length > 3 ? args[3] : string.Empty, args.Length > 4 ? args[4] : string.Empty);
                parser.Parse();
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: ApiaryBlueprintGenerator [input-file] [output-file] [documentation-title] [host:optional] [namespace-prefix:optional]");
            Console.WriteLine("Arguments:");
            Console.WriteLine("[input-file]             : Name of the input XML file");
            Console.WriteLine("[output-file]            : Name of the output text file");
            Console.WriteLine("[documentation-title]    : The API documentation title");
            Console.WriteLine("[host]                   : The address of the real API server (optional)");
            Console.WriteLine("[namespace-prefix]       : The prefix of the desired namespace to be included in the API, all other namespaces will be filtered (optional)");
        }
    }
}
