using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
namespace LoggingCsharp
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Set minimum log level
                .WriteTo.File("Logs/app.log", // Log file path
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Message}{NewLine}") // Custom output format
                .CreateLogger();

            // Set up the service collection
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddSerilog()) // Use Serilog for logging
                .BuildServiceProvider();

            // Create a logger
            var logger = serviceProvider.GetRequiredService < ILogger<Program> >();

            // Log messages
            try
            {
                await LogMessages((Serilog.ILogger)logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while logging messages.");
            }
            finally
            {
                Log.CloseAndFlush(); // Ensure all logs are flushed
            }
        }

        static async Task LogMessages(Serilog.ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
            }
            logger.Information("Application started");
            await Task.Delay(1000); // Simulate some operation
            logger.Information("Performing operation...");
            await Task.Delay(1000); // Simulate some operation
            logger.Information("Application ended");
        }
    }
}