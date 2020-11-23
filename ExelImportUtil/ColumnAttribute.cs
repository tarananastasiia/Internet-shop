using ExelImportUtil.Parcers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Column { get; set; }

        public Type ParserType { get; set; }

        public ISimpleParser Parser => (ISimpleParser)Activator.CreateInstance(ParserType);

        public ColumnAttribute(string column)
        {
            Column = column;
        }
    }
}
