using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace DALHelp
{
    [DataColumn("Hello")]
    public class User
    {
        [DataColumn("ID")]
        public string MyId { get; set; }
        //[DataColumn("Name")]
        public string MyName { get; set; }
    }
}
