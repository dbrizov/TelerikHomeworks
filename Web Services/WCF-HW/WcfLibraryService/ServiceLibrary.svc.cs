using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfLibraryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceLibrary : IServiceLibrary
    {
        /// <summary>
        /// Returns the number of times the second string contains the first string
        /// </summary>
        /// <param name="firstString">The first string</param>
        /// <param name="secondString">The second string</param>
        /// <returns>The number of times the second string contains the first string</returns>
        public int GetNumberOfOccurences(string firstString, string secondString)
        {
            int count = 0;
            int index = secondString.IndexOf(firstString);

            while (index >= 0)
            {
                count++;
                index = secondString.IndexOf(firstString, index + 1);
            }

            return count;
        }
    }
}
