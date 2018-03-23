using System;
using System.IO;
using System.Text;

namespace HotelManagmentLogic.Logger
{
    public class ErrorLogger
    {
        public class Error
        {
            public string ErrorMessage { private set; get; }
            public string ErrorSource { private set; get; }
            public DateTime ErrorDate { private set; get; }

            public Error(Exception exception)
            {
                ErrorMessage = exception.Message;
                ErrorSource = exception.Source;
                ErrorDate = DateTime.Now;
            }
        }

        public static void AddLog(Error error)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string directoryPath = (string.Format("{0}{1}\\{2}", AppDomain.CurrentDomain.BaseDirectory,
                                                                 Configuration.Config.LoggerFolder,
                                                                 Configuration.Config.LoggerFileName));
            if (!File.Exists(directoryPath))
            {
                CreateLoggerFile(directoryPath);
            }

            using (TextWriter textWriter = new StreamWriter(directoryPath, true))
            {
                textWriter.WriteLine(string.Format("Date: {0} | Message: {1} | Source: {2}", 
                                         error.ErrorDate, error.ErrorMessage, error.ErrorSource));
            }

        }

        private static void CreateLoggerFile(string directoryPath)
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + Configuration.Config.LoggerFolder);
            FileStream fileCreator = File.Create(directoryPath);
            fileCreator.Dispose();
        }
    }
}
