using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DALHelp
{
    internal static class ListExtension
    {
      public  static bool HaveElements<T>(this T t) where T : IEnumerable
        {
            if (null == t)
            {
                return false;
            }
            IEnumerator enumerator = t.GetEnumerator();
            return null == enumerator ? false : enumerator.MoveNext();
        }
    }
    public static class DataTableConverter
    {
        private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

        public static List<T> GetObjects<T>(DataTable dt)
        {
            List<T> list = new List<T>();
            foreach (DataRow item in dt.Rows)
            {
                T target = Activator.CreateInstance<T>();
                DataTableConverter.Bind(item, target);
            }
            return list;
        }

        private static string GetName(MemberInfo member)
        {
            return member.Name;
        }
        public static void Bind(DataRow row, object target)
       {

           Type type = target.GetType();
           
           foreach (DataColumn column in row.Table.Columns)
           {
            
               
               foreach (PropertyInfo property in type.GetProperties(Flags))
               {
                   foreach (DataColumnAttribute att in property.GetCustomAttributes(typeof(DataColumnAttribute), true))
                   {
                       DataTableConverter.Bind(column.ColumnName, target, property, row[column]);
                   }
               }
           }
       }
        private static void Bind(string columnName, object target, FieldInfo field, object value)
        {
            if (GetName(field) == columnName)
            {
                field.SetValue(target, value);
            }
        }
        private static void Bind(string columnName, object target, PropertyInfo property, object value)
        {
            if (GetName(property) == columnName)
            {
                property.SetValue(target, value, null);
            }
        }
    }
}
