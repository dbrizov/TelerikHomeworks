using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace WcfDateService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceDateDisplayer : IServiceDateDisplayer
    {
        public string GetDayAsBulgarianString(DateTime dateTime)
        {
            CultureInfo bulgarianCulture = new CultureInfo("bg-BG");

            string day = bulgarianCulture.DateTimeFormat.DayNames[(int)dateTime.DayOfWeek];
            
            return day;
        }
    }
}
