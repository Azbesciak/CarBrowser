using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Kups.CarBrowser.Core;

namespace Kups.CarBrowser.ConsoleUI
{
    public class ConsoleUi
    {
        private const string LIST_CARS_COMMAND = "cars";
        private const string LIST_DEALERS_COMMAND = "dealers";
        private const string SHOW_HELP_COMMAND = "help";
        private const string EXIT_COMMAND = "exit";

        public static void Main(string[] args)
        {
            var carBrowser = new CarBrowser.CarBrowser();
            PrintInstructions();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == null)
                    continue;
                if (command.StartsWith(EXIT_COMMAND)) return;

                var commandSplit = Regex.Split(command, "\\s");
                switch (commandSplit[0])
                {
                    case LIST_CARS_COMMAND:
                        PrintResult(carBrowser.CarsService, commandSplit);
                        break;
                    case LIST_DEALERS_COMMAND:
                        PrintResult(carBrowser.DealersService, commandSplit);
                        break;
                    case SHOW_HELP_COMMAND:
                        PrintInstructions();
                        break;
                    default:
                        Console.WriteLine("Unknown instruction: '{0}'", command);
                        break;
                }
            }
        }

        private static void PrintResult<T>(IService<T> service, IReadOnlyList<string> args)
        {
            if (args.Count > 1 && long.TryParse(args[1], out var id))
            {
                Console.WriteLine(service.GetById(id));
            }
            else
            {
                Console.WriteLine(service.GetAll());
            }
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Options:\n" +
                              $"{LIST_CARS_COMMAND} [id]: List a car if id specified, otherwise - all\n" +
                              $"{LIST_DEALERS_COMMAND} [id]: List a dealer if id specified, otherwise - all\n" +
                              $"{SHOW_HELP_COMMAND}: shows instructions list\n" +
                              $"{EXIT_COMMAND}: shut down program");
        }
    }
}