﻿using System.Data;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace SqlFramework
{
    public static class SqlUtility
    {
        public static string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=WorkTrackerDB;Trusted_Connection=True;Encrypt=False;";

        public static SqlCommand GetSqlCommand(string sproc)
        {
            SqlCommand cmd;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                cmd = new(sproc, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlCommandBuilder.DeriveParameters(cmd);
            }
            return cmd;
        }

        private static void ExecuteSqlCRUD(SqlCommand cmd)
        {
            try
            {
                SqlConnection conn = new(ConnectionString);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static SqlDataReader ExecuteSql(SqlCommand cmd)
        {
            try
            {
                SqlConnection conn = new(ConnectionString);
                cmd.Connection = conn;
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ExecuteCRUDWrapper(SqlCommand cmd)
        {
            ExecuteSqlCRUD(cmd);
        }
        public static List<T> GetGenericObjectListFromDB<T>(SqlCommand cmd) where T : new()
        {
            List<T> lst = new();
            List<PropertyInfo> props;
            using (SqlDataReader dr = ExecuteSql(cmd))
            {
                while (dr.Read())
                {
                    T item = new();
                    props = typeof(T).GetProperties().ToList();
                    foreach (PropertyInfo p in props)
                    {
                        if (p.CanWrite)
                        {
                            var dbval = dr.GetValue(dr.GetOrdinal(p.Name));
                            var setval = (dbval != DBNull.Value ? dbval : null);
                            p.SetValue(item, setval);
                        }
                    }
                    lst.Add(item);
                }
                return lst;
            }
        }

        public static void SaveObjectToDatabase(object obj)
        {
            
        }

    }
}