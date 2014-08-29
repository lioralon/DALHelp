using DALLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DALHelp
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=ipp3;User Id=sa;Password=pwcwelcome#1; ");
            //connection.Open();
            //SqlCommand command = new SqlCommand("select * from dbo.users", connection);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn { ColumnName = "Name" });
            dt.Columns.Add(new DataColumn { ColumnName = "ID" });
            DataRow dr = dt.NewRow();
            dr["Name"] = "tom";
            dr["ID"] = "1";
            dt.Rows.Add(dr);
            User u = new User();
            var info = u.GetType();
            var properties = info.GetProperties(System.Reflection.BindingFlags.Public);
            var attributes = Attribute.GetCustomAttributes(typeof(DataColumnAttribute), true);
            //Console.WriteLine(classAttribute.Name);

            List<User> t = DataTableConverter.GetObjects<User>(dt);
            Console.ReadKey();
        }
    }
}
