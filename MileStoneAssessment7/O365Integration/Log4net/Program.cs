using System;
using log4net;
using log4net.Config;

namespace Log4net
{
    internal class Program
    {
        private static readonly ILog logger = log4net.LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            // Configure Log4net from App.config
            XmlConfigurator.Configure();

            try
            {
                LogMessages();
            }
            catch (Exception ex)
            {
                logger.Error("An error occurred during processing", ex);
            }
        }

        static void LogMessages()
        {
            logger.Info("Application started");
            // Simulate a warning condition
            logger.Warn("Low disk space");
            // Simulate an error
            throw new Exception("Simulated exception for logging purposes.");
        }
    }
}
