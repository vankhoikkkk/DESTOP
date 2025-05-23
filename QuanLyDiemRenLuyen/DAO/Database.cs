using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemRenLuyen.DAO
{
    public class Database
    {
        private static Database instanrce;

        public static Database Instanrce
        { get
            {
                if (Database.instanrce == null)
                {
                    Database.instanrce = new Database();
                }
                return Database.instanrce;
            }
            private set => instanrce = value;
        }

        private Database() { }



        private string conn = @"Data Source=DESKTOP-IIAQ9MJ\SQLEXPRESS;Initial Catalog=QuanLyDiemRenLuyen;Integrated Security=True;";



        public DataTable ExectuteQuery(string query, object[] paramaters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (paramaters != null)
                {
                    string[] listStr = query.Split(' ');
                    int i = 0;
                    foreach (string str in listStr)
                    {
                        if (str.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(str, paramaters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                dataAdapter.Fill(dt);
                connection.Close();

            }

            return dt;
        }

        public int ExectuteNonQuery(string query, object[] paramaters = null)
        {
            int dataRow = 0;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (paramaters != null)
                {
                    string[] listStr = query.Split(' ');
                    int i = 0;
                    foreach(string str in  listStr)
                    {
                        if (str.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(str, paramaters[i]);
                            i++;
                        }
                    }
                }
                dataRow = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return dataRow;
        } 

        public object ExectuteScalar(string query, object[] paramaters = null)
        {
            object result = 0;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if(paramaters != null)
                {
                    string[] listStr = query.Split(' ');
                    int i = 0;
                    foreach(string str in listStr)
                    {
                        if(str.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(str, paramaters[i]);
                            i++;
                        }
                    }
                }
                result = cmd.ExecuteScalar();
                connection.Close();
            }
            return result;
        }
    
    }
}
