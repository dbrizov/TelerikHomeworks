using System;
using log4net;
using log4net.Config;

namespace log4netDemo
{
    class DemoMain
    {
        private static readonly ILog Debug = LogManager.GetLogger("Debug");
        private static readonly ILog Exceptions = LogManager.GetLogger("Exceptions");

        public static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            try
            {
                Debug.Info("Bla bla bla bla bla");
                int.Parse("This will throw an exception ofc :D");
            }
            catch (Exception ex)
            {
                Exceptions.Error(ex.Message);
            }
        }
    }
}
