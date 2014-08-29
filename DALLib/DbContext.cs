using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALLib
{
    public static class DBHelp
    {
        private static Func<string, DbContext> executing;

        static DBHelp()
        {
            executing = new Func<string, DbContext>(DBHelp.GetDefaultDbContext);
        }
        private static DbContext GetDefaultDbContext(string connectionSting)
        {
            return new DbContext(connectionSting);
        }
        public static Func<string, DbContext> CreateDefaultDbContext
        {
            get
            {
                return executing;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                executing = value;
            }
        }

        public static T GetDataItem<T>()
           where T: class, new ()
        {
           var t =  Activator.CreateInstance(typeof(DALlib));
            return null;
        }

        public static T GetDataItem<T>(string sql) where T : class, new()
        {

            using (DbContext context = executing(sql))
            {

            }
            return null;
        }
        public static DbContext GetDbContext(string connectionString)
        {
            return new DbContext(connectionString);
        }

    }
    public class DbContext : IDisposable
    {
        private DbConnection _dbConnection;
        private DbTransaction _dbTransaction;
        private DbCommand _commmand;
        public delegate void DbContextEventHandler(DbContext context);
        public delegate void DbContextExceptionHandler(DbContext context, Exception ex);

        public static event DbContextEventHandler OnAfterExecuted;
        public static event DbContextEventHandler AfterExecuted;
        public static event DbContextEventHandler OnOpenConnection;

        public DbContext(bool isTranscation)
        {

        }

        public DbContext(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);


        }


        public void Dispose()
        {

            if (_dbConnection != null)
            {
                _dbConnection.Close();
            }
        }
    }
}
