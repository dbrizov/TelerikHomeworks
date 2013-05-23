using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CatalogOfFreeContent
{
    public interface ICatalog
    {
        /// <summary>
        /// Adds a new IContent instance to the ICatalog instance
        /// </summary>
        /// <param name="content">The IContent that will be added</param>
        void Add(IContent content);

        /// <summary>
        /// Gets all of the (title, content) pairs
        /// </summary>
        /// <param name="title">The title from the (title, content) pairs</param>
        /// <param name="numberOfContentElementsToList">
        /// The number of the items that will be returned.
        /// If The given number is bigger than the found items, then only the found items are returned
        /// </param>
        /// <returns>
        /// IEnumberable collection of (title, content) pairs
        /// </returns>
        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        /// <summary>
        /// Updates the url in the content of all (title, content) pairs
        /// </summary>
        /// <param name="oldUrl">The URL that will be replaced</param>
        /// <param name="newUrl">The URL that will replace the old URL</param>
        /// <returns>
        /// The number of all updated URLs in the (title, content) pairs
        /// </returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
