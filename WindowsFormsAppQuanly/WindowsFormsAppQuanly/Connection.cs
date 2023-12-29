using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsAppQuanly
{
    internal class Connection
    {
        private static string stringConnection = @"Data Source=DESKTOP-S7AOFL6\SQLEXPRESS;Initial Catalog=QLCH;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
