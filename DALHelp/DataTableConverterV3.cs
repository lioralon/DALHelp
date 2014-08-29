using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DALHelp
{
   public static  class DataTableConverter
    {
       public static List<T> GetObjects<T>(DataTable dt)
       {
           List<T> list = new List<T>();
           foreach (DataRow item in dt.Rows)
           {
               T target = Activator.CreateInstance<T>();
               DataColumnAttribute.Bind(item, target);
               list.Add(target);
           }
           return list;
       }
    }
}
