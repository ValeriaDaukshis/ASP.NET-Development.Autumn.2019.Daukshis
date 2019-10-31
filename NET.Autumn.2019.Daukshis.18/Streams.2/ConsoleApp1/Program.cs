using System;
using System.IO;
using System.Reflection;
using System.Text;
using OfficeOpenXml.Core.ExcelPackage;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\dauks\Streams.2\Streams.Tests\Planets.xlsx";
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path)))
            {
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                var sb = new StringBuilder(); //this is your data
                for (int rowNum = 1; rowNum <= totalRows; rowNum++) //select starting row here
                {
                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    sb.AppendLine(string.Join(",", row));
                }
            }
        }
    }
}