using System;
using System.Linq;
using System.Text;

namespace CatalogOfFreeContent
{
    public interface ICommand
    {
        /// <summary>
        /// The type of the command
        /// </summary>
        CommandType Type { get; set; }

        /// <summary>
        /// The original for of the command (i.e. "Add book: title, author, size, URL")
        /// </summary>
        string OriginalForm { get; set; }

        /// <summary>
        /// The name of the command (i.e. "Add", "Find", "Update"...)
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The parameters of the command. (i.e. "One" and "3" in "Find: One; 3")
        /// </summary>
        string[] Parameters { get; set; }

        /// <summary>
        /// Parses a command from a string representation to it's CommandType enum representation
        /// </summary>
        /// <returns>The command it representation of (CommandType enum)</returns>
        CommandType ParseCommandType(string commandName);

        /// <summary>
        /// Parses the name of the command from it's original form.
        /// (i.e. "Add book" from "Add book: title; author; size; URL")
        /// </summary>
        /// <returns>
        /// The name of the command
        /// </returns>
        string ParseName();

        /// <summary>
        /// Parses the parameters of the command from it's original form.
        /// (i.e. "One" and "3" from "Find: One; 3"
        /// </summary>
        /// <returns>
        /// String array of the command's parameters
        /// </returns>
        string[] ParseParameters();
    }
}
