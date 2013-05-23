using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOfFreeContent
{
    public interface ICommandExecutor
    {
        /// <summary>
        /// Executes an ICommand inside an ICatalog and saves the result in a StringBuilder
        /// </summary>
        /// <param name="contentCatalog">The ICatalog</param>
        /// <param name="command">The ICommand</param>
        /// <param name="output">The StringBuilder</param>
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output);
    }
}
