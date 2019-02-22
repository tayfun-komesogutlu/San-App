using San_Tsg_Project.Interfaces;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace San_Tsg_Project.Loggers
{
    internal class FileLogger : ILogger
    {
        /// <summary>
        /// this method used for write log to txt file
        /// </summary>
        /// <param name="methodBase"></param>
        /// <param name="message"></param>
        public void Log(MethodBase methodBase, string message)
        {
            var logPath = ConfigurationManager.AppSettings["San_Tsg.LoggerPath"].TrimEnd('/');
            var logName = DateTime.Now.ToString("yyyyMMdd_HHmm") + ".txt";
            if (methodBase.ReflectedType == null) return;
            var logMessage =
                $"Namespace: {methodBase.ReflectedType.Namespace}\r\nClass: {methodBase.ReflectedType.Name}\r\nMethod: {methodBase.Name}\r\nMessage: {message}";
            var path = Path.Combine(logPath, logName);

            if (!Directory.Exists((logPath)))
                Directory.CreateDirectory(logPath);
            var sw = new StreamWriter(path, true);
            sw.WriteLine(logMessage);
            sw.Close();
            sw.Dispose();
        }
    }
}
