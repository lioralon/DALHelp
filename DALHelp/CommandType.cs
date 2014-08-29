using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALHelp
{
    /// <summary>
    /// Command type for different scenarios
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// Normal Sql Text 
        /// </summary>
        SqlTextNoParams =0,
        /// <summary>
        /// Normal sql Text with Parameters
        /// </summary>
        SqlTextWithParams =1,
        /// <summary>
        /// Stored Procedure
        /// </summary>
        StoreProcedure =2,
        /// <summary>
        /// XML command
        /// </summary>
        XmlCommand=3
        
        
    }
}
