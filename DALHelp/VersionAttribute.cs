using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALHelp
{
     [AttributeUsage(AttributeTargets.Class)]
    public class VersionAttribute : Attribute
    {
         public VersionAttribute(string name)
         {
             Name = name;
         }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Describtion { get; set; }
    }
}
