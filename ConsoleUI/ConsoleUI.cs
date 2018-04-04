using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Kups.CarBrowser.Core;

namespace Kups.CarBrowser.ConsoleUI
{
    public static class ConsoleUi
    {
        private const string ListCarsCommand = "cars";
        private const string ListDealersCommand = "dealers";
        private const string ShowHelpCommand = "help";
        private const string ExitCommand = "exit";

        public static void Main(string[] args)
        {
            var carBrowser = new BL.CarBrowser();
            PrintInstructions();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == null)
                    continue;
                if (command.StartsWith(ExitCommand)) return;

                var commandSplit = Regex.Split(command, "\\s");
                switch (commandSplit[0])
                {
                    case ListCarsCommand:
                        PrintResult(carBrowser.CarsService, commandSplit);
                        break;
                    case ListDealersCommand:
                        PrintResult(carBrowser.DealersService, commandSplit);
                        break;
                    case ShowHelpCommand:
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
                var byId = service.GetById(id);
                Console.WriteLine(byId != null ? byId.ToString() : "Not found");
            }
            else
            {
                service.GetAll().ForEach(c => Console.WriteLine(c));
            }
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Options:\n" +
                              $"{ListCarsCommand} [id]: List a car if id specified, otherwise - all\n" +
                              $"{ListDealersCommand} [id]: List a dealer if id specified, otherwise - all\n" +
                              $"{ShowHelpCommand}: shows instructions list\n" +
                              $"{ExitCommand}: shut down program");
        }
    }
}