using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExelImportUtil.Parcers.Impl
{
    public class ListParser:ISimpleParser
    {
        public object Parce(string text)
        {
            var res = text.Split(" ").ToList();
            return res;
        }
    }
}
