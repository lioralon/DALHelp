using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DALHelp
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class DataColumnAttribute : Attribute
    {
       public DataColumnAttribute(string name)
        {
            Name = name;
        }
        public string  Name { get; set; }
    }
}
