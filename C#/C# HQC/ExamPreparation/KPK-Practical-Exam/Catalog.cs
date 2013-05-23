using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace CatalogOfFreeContent
{
    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> urls;
        private OrderedMultiDictionary<string, IContent> titles;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.titles = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.urls = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public int Count
        {
            get
            {
                return this.titles.KeyValuePairs.Count;
            }
        }

        public void Add(IContent content)
        {
            this.titles.Add(content.Title, content);
            this.urls.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList =
                from content in this.titles[title]
                select content;

            return contentToList.Take(numberOfContentElementsToList);
        }


        public int UpdateContent(string oldURL, string newURL)
        {
            int elementsCount = 0;
            List<IContent> contentToList = this.urls[oldURL].ToList();

            foreach (Content content in contentToList)
            {
                this.titles.Remove(content.Title, content);
                elementsCount++;
            }

            this.urls.Remove(oldURL);


            foreach (IContent content in contentToList)
            {
                content.URL = newURL;
            }

            foreach (IContent content in contentToList)
            {
                this.titles.Add(content.Title, content);
                this.urls.Add(content.URL, content);
            }

            return elementsCount;
        }
    }
}
