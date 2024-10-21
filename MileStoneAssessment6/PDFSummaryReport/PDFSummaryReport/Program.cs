using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFSummaryReport
{
    internal class Program
    { 

            static void Main(string[] args)
            {
                //set pdfand csv path
                string csvPath = "C:\\Users\\Administrator\\Desktop\\DotNet Training\\DotNetLabTasks\\MileStoneAssessment6\\PDFSummaryReport\\Files\\data.csv"; // Path to your CSV file
                string pdfPath = "C:\\Users\\Administrator\\Desktop\\DotNet Training\\DotNetLabTasks\\MileStoneAssessment6\\PDFSummaryReport\\Files\\SummaryReport.pdf"; // Output PDF file path

                List<Employee> employees = ReadCsv(csvPath);
                GeneratePdf(pdfPath, employees);
                Console.WriteLine($"PDF report generated at {pdfPath}");
            }

            //Read CSV file
            static List<Employee> ReadCsv(string path)
            {
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return new List<Employee>(csv.GetRecords<Employee>());
                }
            }

            static void GeneratePdf(string pdfPath, List<Employee> employees)
            {
                
                Document document = new Document();

                // Create a PDF writer
                PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));

                
                document.Open();

                
                Font titleFont = FontFactory.GetFont("Arial", 24, Font.BOLD);
                Paragraph title = new Paragraph("Summary Table", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                
                document.Add(new Paragraph("\n"));

                // Create a table with headers
                PdfPTable table = new PdfPTable(2); 
                table.AddCell("Name");
                table.AddCell("Amount");

                // Add data to the table
                foreach (var employee in employees)
                {
                    table.AddCell(employee.Name);
                    table.AddCell(employee.Amount.ToString());
                }

                document.Add(table);

                document.Close();
            }
        }
    }