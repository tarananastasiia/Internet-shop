using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Parcers
{
    public interface ISimpleParser
    {
        object Parce(string text);
    }
}
