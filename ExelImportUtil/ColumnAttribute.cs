using ExelImportUtil.Parcers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil
{
    public class ColumnAttribute :Attribute 
    {
        public int Column { get; set; }

        public Type ParserType { get; set; }

        public ISimpleParser Parser => (ISimpleParser)Activator.CreateInstance(ParserType); 

        public ColumnAttribute(int column)
        {
            Column = column;
        }
    }
}
