using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Parcers.Impl
{
    public class IntParser : ISimpleParser
    {
        public object Parce(string text)
        {
            var res = Int32.Parse(text);
            return res;
        }
    }
}
