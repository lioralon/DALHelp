using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DALHelp
{
    public class DataColumnAttribute : Attribute
    {
        private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy;
        private string _name = null;
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public DataColumnAttribute()
        {

        }
        public DataColumnAttribute(string name)
        {
            _name = name;
        }
        private string GetName(MemberInfo member)
        {
            return _name ?? member.Name;
        }
        public static void Bind(DataRow row, object target)
        {
            Type type = target.GetType();
            PropertyInfo[] fi = type.GetProperties(Flags);
            foreach(var f in fi)
            {
                DataColumnAttribute[] atts = (DataColumnAttribute[])f.GetCustomAttributes(typeof(DataColumnAttribute), true);
                string realColumnName = (atts != null && atts.Length > 0 && atts[0] is DataColumnAttribute) ? atts[0].Name : f.Name;

                if (row.Table.Columns.Contains(realColumnName))
                {
                    try
                    {
                        f.SetValue(target, Convert.ChangeType(row[realColumnName], f.PropertyType), null);
                    }
                    catch { }
                }
            }
        }
        //public static void Bind(DataRow row, object target)
        //{
        //    Type type = target.GetType();
        //    foreach (DataColumn column in row.Table.Columns)
        //    {
        //        foreach (FieldInfo field in type.GetFields(Flags))
        //        {
        //            var x = type.GetCustomAttributes(typeof(DataColumnAttribute), true);
        //            foreach (DataColumnAttribute att in type.GetCustomAttributes(typeof(DataColumnAttribute), true))
        //            {
        //                att.Bind(column.ColumnName, target, field, row[column]);
        //            }

        //        }
        //        foreach (PropertyInfo property in type.GetProperties(Flags))
        //        {
        //            foreach (DataColumnAttribute att in type.GetCustomAttributes(typeof(DataColumnAttribute), true))
        //            {
        //                att.Bind(column.ColumnName, target, property, row[column]);
        //            }
        //        }
        //    }
        //}
        //private void Bind(string columnName, object target, FieldInfo field, object value)
        //{
        //    if (GetName(field) == columnName)
        //    {
        //        field.SetValue(target, value);
        //    }
        //}
        //private void Bind(string columnName, object target, PropertyInfo property, object value)
        //{
        //    if (GetName(property) == columnName)
        //    {
        //        property.SetValue(target, value, null);
        //    }
        //}
    }
}
