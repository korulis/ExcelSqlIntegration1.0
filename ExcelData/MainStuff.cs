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
    public class MainStuff
    {
        private List<string> _readRange = new List<string>();

        private Dictionary<string, string> _data = new Dictionary<string, string>();

        public MainStuff()
        {

        }

        public void DoStuff()
        {
            const string filePathOrStream = @"C:\Users\k.blazevicius\Desktop\test.xlsx";
            ReadExcelFileSAX(filePathOrStream);
        }




        void ReadExcelFileSAX(string fileName)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);

                Sheet theSheet = workbookPart.Workbook.Descendants<Sheet>().FirstOrDefault(s => s.Name == "SpecialSheetName");

                List<Cell> theCells = worksheetPart.Worksheet.Descendants<Cell>().ToList();

                var rawRange = new List<string>();

                var tempList = new List<string>();
                foreach (var c in theCells)
                {
                    tempList.Add(c.InnerText);
                    rawRange.Add(c.CellReference);
                }



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


                Console.WriteLine(tempList.Count);
            }
        }

    }
}
