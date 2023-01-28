using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CSharp.Kit.Database
{
    public class SqlServerHelper : IDatabaseHelper
    {
        private SqlCommand command;
        private SqlConnection connection;

        private SqlTransaction transaction;

        String connectionString = "";
        public String ServerIp = "";
        public int Port { get; set; } = 1433;

        public SqlServerHelper()
        {
            connection = new SqlConnection();
            command = new SqlCommand();
        }
        public void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        public void OpenConnection()
        {
            if (connection != null)
            {
                if (String.IsNullOrWhiteSpace(connection.ConnectionString))
                {
                    if (!String.IsNullOrWhiteSpace(connectionString))
                    {
                        connection.ConnectionString = connectionString;
                    }
                    else
                    {
                        throw new Exception("未配置正确的连接字符串！");
                    }
                }
                else
                {
                    if (command.Connection == null)
                    {
                        command.Connection = connection;
                    }
                    connection.Open();
                }
            }
        }

        public void BeginTransaction()
        {
            if (connection != null)
            {
                transaction = connection.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (transaction != null)
            {
                transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
        }

        public int ExcuteNonQuery(string sql)
        {
            command.CommandText = sql;
            return command.ExecuteNonQuery();
        }

        public DataSet ExcuteQueryDataSet(string sql)
        {
            command.CommandText = sql;
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        public DbDataReader ExcuteQueryDataReader(string sql)
        {
            command.CommandText = sql;
            return command.ExecuteReader();
        }

        
    }
}