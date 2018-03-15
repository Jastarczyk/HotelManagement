using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagmentLogic.Logger
{
    public class ErrorLogger
    {
        public class Error
        {
            public string ErrorMessage { private set; get; }
            public string ErrorSource { private set; get; }
            public DateTime ErrorDate { private set; get; }

            public Error(string errorMessage, string errorSource)
            {
                ErrorMessage = errorMessage;
                ErrorSource = errorSource;
                ErrorDate = DateTime.Now;
            }
        }

        public static void AddLog(Error error)
        {
            string directoryPath = (string.Format("{0}\\{1}\\{2}", AppDomain.CurrentDomain.BaseDirectory,
                                                                   Configuration.Config.LoggerFolder,
                                                                   Configuration.Config.LoggerFileName));
            if (!File.Exists(directoryPath))
            {
                CreateLoggerFile(directoryPath);
            }

            //TODO should use XML logger? Remove magic strings! Try catch needed in case of emergency
            using (TextWriter textWriter = new StreamWriter(directoryPath))
            {
                textWriter.WriteLine(string.Format("Date: {0} | Message: {1} | Source: {2}", error.ErrorDate, error.ErrorMessage, error.ErrorSource));
            }

        }

        private static void CreateLoggerFile(string directoryPath)
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + Configuration.Config.LoggerFolder);
            File.Create(directoryPath);
        }
    }
}
