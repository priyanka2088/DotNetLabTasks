using System;
using System.Diagnostics;

namespace PythonScriptInvokeProject
{
    internal class Program
    {
            static void Main(string[] args)
            {
                // Check if  two numbers are provided
                if (args.Length != 2)
                {
                    Console.WriteLine("Usage: PythonInvoker <num1> <num2>");
                    return;
                }

                string num1 = args[0];
                string num2 = args[1];

                // Set Path for Python.exe and Script
                string pythonPath = "C:\\Users\\Administrator\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe"; // Python path
                string scriptPath = "C:\\Users\\Administrator\\Desktop\\DotNet Training\\DotNetLabTasks\\MileStoneAssessment6\\PythonScriptInvokeProject\\Python Files\\sum_script.py"; // script path

                // Create a process to run the Python script
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = pythonPath,
                    Arguments = $"\"{scriptPath}\" {num1} {num2}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(start))
                {
                    using (System.IO.StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.WriteLine($"The sum of {num1} and {num2} is: {result}");
                    }
                }
            }
        }
    }