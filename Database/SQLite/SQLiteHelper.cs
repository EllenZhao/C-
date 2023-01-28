using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace CSharp.Kit.Database
{
    public class SQLiteHelper : IDatabaseHelper
    {
        private SQLiteCommand command;
        private SQLiteConnection connection;

        private SQLiteTransaction transaction;

        private String filePath = "";

        public String FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                ConnectionString = "Data Source = " + value;
            }
        }

        private String connectionString = "";
        public String ConnectionString
        {
            get { return connectionString; }
            set
            {
                connectionString = value;
                String[] temp = connectionString.Split('=');
                if (temp[0].Trim() == "Data Source" && !String.IsNullOrWhiteSpace(Path.GetFileName(temp[1].Trim())))
                {
                    filePath = temp[1];
                }

                if (connection != null)
                {
                    connection.ConnectionString = value;
                }
                else
                {
                    connection = new SQLiteConnection(connectionString);
                }
            }
        }

        public SQLiteHelper()
        {
            connection = new SQLiteConnection();
            command = new SQLiteCommand();
            command.Connection = connection;
        }

        public SQLiteHelper(String filePath)
        {
            connection = new SQLiteConnection();

            FilePath = filePath;

            command = new SQLiteCommand();
            command.Connection = connection;
        }

        public void BeginTransaction()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                transaction = connection.BeginTransaction();
            }
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void Commit()
        {
            if (connection != null)
            {
                transaction.Commit();
            }
        }

        public int ExcuteNonQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public DbDataReader ExcuteQueryDataReader(string sql)
        {
            throw new NotImplementedException();
        }

        public DataSet ExcuteQueryDataSet(string sql)
        {
            throw new NotImplementedException();
        }

        public void OpenConnection()
        {
            if (connection != null && connection.State != ConnectionState.Open)
            {
                connection.Open();
                command.Connection = connection;
            }

        }

        public void Rollback()
        {
            if (connection != null)
            {
                transaction.Rollback();
            }
        }
    }
}