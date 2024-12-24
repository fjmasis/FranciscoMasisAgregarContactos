using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace FranciscoMasisAgregarContactos.App_Code
{
    public class DatabaseHelper
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["FranciscoMasisAgregarContactos"].ConnectionString;
        }

        public void LogError(Exception ex)
        {
            string logFilePath = @"C:\WebP\errorFranciscoMasisAgregarContactos.txt";

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} - Error: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                writer.WriteLine();
            }
        }


        public DataTable ExecuteSelectQuery(string query, SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (sqlParameters != null)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddRange(sqlParameters);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }


        public void ExecuteQuery(string query, SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlParameters);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        internal int ExecuteNonQuery(string query, SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (sqlParameters != null)
                        {
                            cmd.Parameters.AddRange(sqlParameters);
                        }
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }


    }
}