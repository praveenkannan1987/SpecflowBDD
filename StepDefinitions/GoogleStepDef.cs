using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
//using Excel = Microsoft.Office.Interop.Excel;

namespace TestProject.StepDefinitions
{
    [Binding]
    public sealed class GoogleStepDef
    {
        //Excel.Application xlApp;
        //Excel.Workbook xlWorkBook;
        //Excel.Worksheet xlWorkSheet;
        //object misValue = System.Reflection.Missing.Value;
        private IWebDriver driver;
        public GoogleStepDef(IWebDriver driver)
        {
            this.driver = driver;
        }
        [Given(@"I open google file")]
        public void GivenIOpenGoogleFile()
        {
            driver.Url = "https://www.google.com";
        }

        [When(@"I enter text ""([^""]*)""")]
        public void WhenIEnterText(string text)
        {
            driver.FindElement(By.XPath("s//textarea[@title='Search']")).SendKeys(text);
            //xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Open(fi);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Flow Chart");
            //xlWorkBook.Close(true, misValue, misValue);
            //xlApp.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);
            //File.Delete(fi);
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

        //[When(@"I enter text and passable")]
        //public void WhenIEnterTextAndPassable(Table table)
        //{
        //    var dataTable = ToDataTable(table);
        //    foreach (DataRow row in dataTable.Rows) {
        //      var text = row.ItemArray[0].ToString();
        //    }
        //}

        [When(@"I enter text and pass ""([^""]*)""")]
        public void WhenIEnterTextAndPass(string text)
        {
            driver.FindElement(By.XPath("//textarea[@title='Search']")).SendKeys(text);
            //connectionDBstring = @"" + ConfigurationManager.AppSettings["BroadcastDatabaseQA1"];
            //cnn = new SqlConnection(connectionDBstring);
            //cnn.Open();
            // sql = "select B1.Empid,B2.Name from emp as B1 left join empName as B2 On B1.Empid=B2.Empid
            //command = new SqlCommand(sql, cnn);
            //dataReader = command.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    //Distribution=Distribution+
            //    string value1 = (xlWorkSheet.Cells[i + 3, j].value).ToString();
            //    var charsToRemove = new string[] { "$", "," };
            //    foreach (var c in charsToRemove)
            //    {
            //        value1 = value1.Replace(c, string.Empty);
            //    }
            //    string value2 = String.Format("{0:C0}", dataReader.GetValue(0));
            //    //var charsToRemove = new string[] { "$", "," };
            //    foreach (var c in charsToRemove)
            //    {
            //        value2 = value2.Replace(c, string.Empty);
            //    }
            //    if (value2 != value1)
            //        verifyexportfilefail(i + 3, j, fi, value2, value1);
            //    value1 = (xlWorkSheet.Cells[i + 5, j].value).ToString();
            //    //charsToRemove = new string[] { "$", "," };
            //    foreach (var c in charsToRemove)
            //    {
            //        value1 = value1.Replace(c, string.Empty);
            //    }
            //    value2 = String.Format("{0:C0}", dataReader.GetValue(1));
            //    //var charsToRemove = new string[] { "$", "," };
            //    foreach (var c in charsToRemove)
            //    {
            //        value2 = value2.Replace(c, string.Empty);
            //    }
            //    if (value2 != value1)
            //        verifyexportfilefail(i + 5, j, fi, value2, value1);

            //}
            //cnn.Close();
        }


        //public DataTable ToDataTable(Table table)
        //{
        //    var dataTable = new DataTable();
        //    foreach (var header in table.Header)
        //    {
        //        dataTable.Columns.Add(header, typeof(string));
        //    }

        //    foreach (var row in table.Rows)
        //    {
        //        var newRow = dataTable.NewRow();
        //        foreach (var header in table.Header)
        //        {
        //            newRow.SetField(header,row[header]);
        //        }
        //        dataTable.Rows.Add(newRow);
        //    }
        //    return dataTable;
        //}

    }
}
