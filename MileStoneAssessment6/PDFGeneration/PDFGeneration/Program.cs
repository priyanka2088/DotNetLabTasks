using System;
using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = iTextSharp.text.Image;

namespace PDFGeneration
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string pdfPath = "C:\\Users\\Administrator\\Desktop\\DotNet Training\\DotNetLabTasks\\MileStoneAssessment6\\PDFGeneration\\Files\\SalesReport.pdf";
            GeneratePdf(pdfPath);
            Console.WriteLine($"PDF report generated at {pdfPath}");
        }
        //Generate PDF
        static void GeneratePdf(string pdfPath)
        {
            
            Document document = new Document();

            PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
            
            document.Open();

            // Add title
            Font titleFont = FontFactory.GetFont("Arial", 24, Font.BOLD);
            Paragraph title = new Paragraph("Monthly Sales Report", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Add text
            Font textFont = FontFactory.GetFont("Arial", 12);
            Paragraph text = new Paragraph("Total Sales: $10,000", textFont);
            text.SpacingBefore = 10;
            text.SpacingAfter = 10;
            document.Add(text);

            //Add Image
            string imagePath = "C:\\Users\\Administrator\\Desktop\\DotNet Training\\DotNetLabTasks\\MileStoneAssessment6\\PDFGeneration\\Files\\salesreport.jfif"; 
            if (File.Exists(imagePath))
            {
                Image img = Image.GetInstance(imagePath);
                img.ScaleToFit(300f, 200f); 
                img.Alignment = Element.ALIGN_CENTER;
                document.Add(img);
            }
            else
            {
                Console.WriteLine("Image not found at the specified path.");
            }

            document.Close();
        }
    }
}