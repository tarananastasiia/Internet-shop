using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Validation.Param
{
    public class DoubleValid: IValidator
    {
        public bool IsValid(string param)
        {
            return Double.TryParse(param, out double number);
        }
    }
}
