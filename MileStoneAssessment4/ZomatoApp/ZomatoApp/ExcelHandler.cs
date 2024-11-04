using ClosedXML.Excel;
using System;

namespace ZomatoApp
{
    public class ExcelHandler
    {


        public static void ReadExcel(string filePath)
        {
            var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet(1);

            for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
            {
                string name = worksheet.Cell(row, 1).GetString();
                string address = worksheet.Cell(row, 2).GetString();
                double rating = worksheet.Cell(row, 3).GetDouble();
                Console.WriteLine($"Read Restaurant: {name}, Address: {address}, Rating: {rating}");
            }
        }
    }

}