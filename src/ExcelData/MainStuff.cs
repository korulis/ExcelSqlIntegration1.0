using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace ExcelData
{
    public class MainStuff
    {
        private List<string> _readRange = new List<string>();

        private Dictionary<string, string> _data = new Dictionary<string, string>();

        public MainStuff()
        {

        }


        public Dictionary<string, string> DoStuff(string fileName = @"C:\Users\k.blazevicius\Desktop\test.xlsx")
        {
            using (var spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                var worksheet = spreadsheetDocument.WorkbookPart.Workbook.
                    Descendants<Sheet>().First(s => s.Name == "SpecialSheetName");
                var theCells = worksheet.Descendants<Cell>();

                var gg= theCells.ToList<Cell>();

                IEnumerable<Cell> enumerable = theCells as IList<Cell> ?? theCells.ToList();
                return enumerable.ToDictionary(x => x.CellReference.ToString(), y => y.InnerText);
            }
        }

    }
}
