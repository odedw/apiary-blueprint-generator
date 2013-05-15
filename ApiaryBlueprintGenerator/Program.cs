using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiaryBlueprintGenerator.Logic;

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
                string input = args[0];
                string output = args[1];
                string title = args[2];
                string host = GetArgument("h", args.ToList());
                string description = GetArgument("d", args.ToList());
                string namespacePrefix = GetArgument("n", args.ToList());

                Parser parser = new Parser(input, title, host, description, namespacePrefix);
                var model = parser.Parse();

                BlueprintCreator creator = new BlueprintCreator();
                creator.Create(model, output);
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        private static string GetArgument(string flag, IList<string> args)
        {
            return args.Contains("-" + flag) ? args[args.IndexOf("-" + flag) + 1] : string.Empty;
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: ApiaryBlueprintGenerator [input-file] [output-file] [documentation-title] [-h hostAddress] [-d \"description\"] [-n namespacePrefix]");
            Console.WriteLine("Arguments:");
            Console.WriteLine("[input-file]             : Name of the input XML file");
            Console.WriteLine("[output-file]            : Name of the output text file");
            Console.WriteLine("[documentation-title]    : The API documentation title");
            Console.WriteLine("[-h hostAddress]         : The address of the real API server (optional)");
            Console.WriteLine("[-d description]         : This is the right place to mention the common rules that all your API resources follow. Expected formats, authentication requirements etc. (optional)");
            Console.WriteLine("[-n namespace-prefix]    : The prefix of the desired namespace to be included in the API, all other namespaces will be filtered (optional)");
        }
    }
}
