using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.StepDefinitions
{
    [Binding]
    public sealed class DBConnect
    {
        [When(@"I connect to DB connect")]
        public void DbConnection()
        {
            string connectionDBstring = @"username=;password;";
            SqlConnection cnn = new SqlConnection(connectionDBstring);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;
            sql = "select B1.Empid,B2.Name from emp as B1 left join empName as B2 On B1.Empid=B2.Empid";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                dataReader.GetValue(0);
            }
            cnn.Close();
        }

    }
}
