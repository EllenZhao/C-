using System.Data.Common;
using System.Data;

namespace CSharp.Kit
{
    public interface IDatabaseHelper
    {
        public void OpenConnection();

        public void CloseConnection();

        public void BeginTransaction();

        public void Commit();

        public void Rollback();

        public int ExcuteNonQuery(String sql);

        public DataSet ExcuteQueryDataSet(String sql);

        public DbDataReader ExcuteQueryDataReader(String sql);
    }
}