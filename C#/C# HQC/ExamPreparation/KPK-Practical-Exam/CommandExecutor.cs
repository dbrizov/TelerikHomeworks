using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOfFreeContent
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    catalog.Add(new Content(ContentType.Book, command.Parameters));
                    output.AppendLine("Book added");
                    break;

                case CommandType.AddMovie:
                    catalog.Add(new Content(ContentType.Movie, command.Parameters));
                    output.AppendLine("Movie added");
                    break;

                case CommandType.AddSong:
                    catalog.Add(new Content(ContentType.Song, command.Parameters));
                    output.AppendLine("Song added");
                    break;

                case CommandType.AddApplication:
                    catalog.Add(new Content(ContentType.Application, command.Parameters));
                    output.AppendLine("Application added");
                    break;

                case CommandType.Update:
                    if (command.Parameters.Length == 2)
                    {

                    }
                    else
                    {
                        throw new FormatException("The given paremeters must be exactly 2!");
                    }

                    output.AppendLine(String.Format("{0} items updated", catalog.UpdateContent(command.Parameters[0].Trim(), command.Parameters[1].Trim())));
                    break;

                case CommandType.Find:
                    if (command.Parameters.Length != 2)
                    {
                        throw new ArgumentException("Invalid number of parameters!");
                    }

                    int numberOfElementsToList = int.Parse(command.Parameters[1]);

                    IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

                    if (foundContent.Count() == 0)
                    {
                        output.AppendLine("No items found");
                    }
                    else
                    {
                        foreach (IContent content in foundContent)
                        {
                            output.AppendLine(content.TextRepresentation);
                        }
                    }

                    break;

                default:
                    throw new ArgumentException("The given command is unknown to the CommandExecutor");
            }
        }
    }
}
