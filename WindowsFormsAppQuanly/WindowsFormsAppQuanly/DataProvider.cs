using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
            // set {instance = value}
        }
        private DataProvider() { }

        public string connectionString = @"Data Source=DESKTOP-S7AOFL6\SQLEXPRESS;Initial Catalog=QLCH;Integrated Security=True";
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameter != null)
                    {
                        var matches = Regex.Matches(query, @"@\w+");
                        List<string> listPara = new List<string>();

                        foreach (Match match in matches)
                        {
                            string param = match.Value.EndsWith(",") ? match.Value.Remove(match.Value.Length - 1) : match.Value;
                            listPara.Add(param);
                        }
                        if (listPara.Count == parameter.Length)
                        {
                            for (int i = 0; i < parameter.Length; i++)
                            {
                                cmd.Parameters.AddWithValue(listPara[i], parameter[i]);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("The number of parameters does not match the number of values.");
                        }
                    }
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(data);
                    conn.Close();
                }
            }
            return data;
        }

        public string[] GetDataColumn(string query)
        {
            List<string> list = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(0));
                        }
                    }
                    conn.Close();
                }
            }
            return list.ToArray();

        }

        public string GetIdByName(string queryFindId, object[] parameter = null)
        {
            string id = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryFindId, conn))
                {
                    if (parameter != null)
                    {
                        var matches = Regex.Matches(queryFindId, @"@\w+");
                        List<string> listPara = new List<string>();

                        foreach (Match match in matches)
                        {
                            string param = match.Value.EndsWith(",") ? match.Value.Remove(match.Value.Length - 1) : match.Value;
                            listPara.Add(param);
                        }
                        if (listPara.Count == parameter.Length)
                        {
                            for (int i = 0; i < parameter.Length; i++)
                            {
                                cmd.Parameters.AddWithValue(listPara[i], parameter[i]);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("The number of parameters does not match the number of values.");
                        }
                    }
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id = reader[0].ToString();
                    }
                    reader.Close();
                }
            }
            return id;
        }

        // Thực hiện thêm || xóa || sửa 
        public string GenerateId(string queryCountId, string firtsIdStr)
        {
            int count = 1;
            string id = "";
            int startIndex = queryCountId.IndexOf("@");
            string result = queryCountId.Substring(startIndex).Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                bool exists = true;
                while (exists)
                {
                    id = firtsIdStr + count.ToString();
                    using (SqlCommand cmd = new SqlCommand(queryCountId, conn))
                    {
                        cmd.Parameters.AddWithValue(result, id);
                        exists = ((int)cmd.ExecuteScalar() > 0);
                    }
                    count++;
                }
                conn.Close();
            }
            return id;
        }
        public void ExcuteNonQuery(string query, object[] parameter = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameter != null)
                    {
                        var matches = Regex.Matches(query, @"@\w+");
                        List<string> listPara = new List<string>();

                        foreach (Match match in matches)
                        {
                            string param = match.Value.EndsWith(",") ? match.Value.Remove(match.Value.Length - 1) : match.Value;
                            listPara.Add(param);
                        }
                        if (listPara.Count == parameter.Length)
                        {
                            for (int i = 0; i < parameter.Length; i++)
                            {
                                cmd.Parameters.AddWithValue(listPara[i], parameter[i]);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("The number of parameters does not match the number of values.");
                        }
                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateTableInDatabase(DataTable dt, string selectQuery)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Tạo một SqlDataAdapter
                using (SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn))
                {
                    // Sử dụng SqlCommandBuilder để tạo các lệnh INSERT, UPDATE, DELETE tự động
                    using (SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da))
                    {
                        da.Update(dt);
                    }
                }
            }
        }



    }
}
