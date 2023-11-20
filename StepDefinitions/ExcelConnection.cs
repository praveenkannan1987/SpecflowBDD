using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace TestProject.StepDefinitions
{
    [Binding]
    public sealed class ExcelConnection
    {
        Excel.Application? xlApp;
        Excel.Workbook? xlWorkBook;
        Excel.Worksheet? xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        public void Excelconnect()
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open("File.xlsx");
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Contract");


            var value = xlWorkSheet.Cells[1, 2].ToString();

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
                //MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
