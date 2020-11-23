using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Parcers.Impl
{
    public class DoubleParser : ISimpleParser
    {
        public object Parce(string text)
        {
            var res = Double.Parse(text);
            return res;
        }
    }
}
