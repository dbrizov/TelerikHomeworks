using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace CatalogOfFreeContent
{
    public class FreeContentMain
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            List<ICommand> parsedCommands = GetParsedCommands();
            foreach (ICommand command in parsedCommands)
            {
                commandExecutor.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> GetParsedCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool endIsReached = false;

            do
            {
                string inputLine = Console.ReadLine();
                endIsReached = (inputLine.Trim() == "End");
                if (!endIsReached)
                {
                    commands.Add(new Command(inputLine));
                }

            }
            while (!endIsReached);

            return commands;
        }
    }
}
