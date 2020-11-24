using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExelImportUtil
{
    public interface IValidator
    {
        bool IsValid(string param);
    }
}
