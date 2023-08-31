using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.Utilities
{
    public class ExcelUtils
    {
        public static object[] GetSheetIntoObjectArray(string filePath, string sheetname)
        {
            XLWorkbook book = new XLWorkbook(filePath);
            var sheet = book.Worksheet(sheetname);
            var range = sheet.RangeUsed();
            int rowCount = range.RowCount();
            int colCount = range.ColumnCount();

            object[] allDataSet = new object[rowCount - 1];

            //write logic to print all cell values
            for (int r = 2; r <= rowCount; r++)
            {
                object[] data = new object[colCount];
                for (int c = 1; c <= colCount; c++)
                {
                    data[c - 1] = range.Cell(r, c).GetString();
                }
                allDataSet[r - 2] = data;
            }

            book.Dispose();

            return allDataSet;
        }
    }
}
