using System;

namespace CatalogOfFreeContent
{
    public interface IContent : IComparable
    {
        /// <summary>
        /// The title of the IContent instance
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// The author of the IContent instance
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// The size of the IContent instance
        /// </summary>
        long Size { get; set; }

        /// <summary>
        /// The URL of the IContent instance
        /// </summary>
        string URL { get; set; }

        /// <summary>
        ///  The ContentType of the IContent instance
        /// </summary>
        ContentType Type { get; set; }

        /// <summary>
        /// The text representation of the IContent instance
        /// </summary>
        string TextRepresentation { get; set; }
    }
}
