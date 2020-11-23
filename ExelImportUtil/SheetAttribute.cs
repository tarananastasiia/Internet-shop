using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SheetAttribute : Attribute
    {
        public string Sheet { get; set; }
        public SheetAttribute(string sheet)
        {
            Sheet = sheet;
        }
    }
}
