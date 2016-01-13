using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace ExcelData
{
    public class ExcelFileParser
    {
        private readonly string _filePath;

        public ExcelFileParser(string filePath = @"C:\Users\k.blazevicius\Desktop\test.xlsx")
        {
            _filePath = filePath;
        }


        public void GetDataFromSheet(string worksheetName)
        {
            using (var spreadsheetDocument = SpreadsheetDocument.Open(_filePath, false))
            {
                var workbookPart = spreadsheetDocument.WorkbookPart;
                var theSheet = workbookPart.Workbook.Descendants<Sheet>().FirstOrDefault(s => s.Name == worksheetName);
                var worksheetPart = (WorksheetPart)(workbookPart.GetPartById(theSheet.Id));
                var theCells = worksheetPart.Worksheet.Descendants<Cell>().ToList();

                var rawRange = new List<string>();
                var tempList = new List<string>();
                foreach (var c in theCells)
                {
                    tempList.Add(c.InnerText);
                    rawRange.Add(c.CellReference);
                }

                Console.WriteLine(tempList.Count);

            }
        }






        private List<string> _readRange = new List<string>();
        private Dictionary<string, string> _data = new Dictionary<string, string>();

        //#if !DEBUG
        //                while (reader.Read())
        //                {
        //                    if (reader.ElementType == typeof(Cell))
        //                    {
        //                        var intas = int.Parse(reader.LoadCurrentElement().InnerText);
        //                        tempList.Add(intas.ToString());
        //
        //                        _readRange.Add();
        //                        var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
        //                        var theCell = stringTable?.SharedStringTable.ElementAt(intas);
        //                        var value = theCell?.InnerText;
        //
        //                        tempList.Add(value);
        //                        rawRange.Add(((Cell)theCell).CellReference);
        //#endif
        //                    }
        //                }
        public Dictionary<string, string> ParseWorksheetOld(string fileName = @"C:\Users\k.blazevicius\Desktop\test.xlsx", string worksheetName = "SpecialSheetName")
        {
            using (var spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                var sheet = spreadsheetDocument.WorkbookPart.Workbook.
                    Descendants<Sheet>().First(s => s.Name == worksheetName);
                var theCells = sheet.Descendants<Cell>();
                var gg = theCells.ToList<Cell>();

                IEnumerable<Cell> enumerable = theCells as IList<Cell> ?? theCells.ToList();
                return enumerable.ToDictionary(x => x.CellReference.ToString(), y => y.InnerText);
            }
        }

    }
}
