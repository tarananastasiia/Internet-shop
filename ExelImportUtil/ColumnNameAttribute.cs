using ExelImportUtil.Parcers;
using ExelImportUtil.Validation;
using ExelImportUtil.Validation.Param;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnNameAttribute : Attribute
    {
        public string Column { get; set; }

        public Type ParserType { get; set; }

        public Type ValidType { get; set; }

        public ISimpleParser Parser => (ISimpleParser)Activator.CreateInstance(ParserType);
        public IValidator Validator => (IValidator)Activator.CreateInstance(ValidType);
        public ColumnNameAttribute(string column)
        {
            Column = column;
        }
    }
}
