using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Validation.Param
{
    public class IntValid : IValidator
    {
        public bool IsValid(string param)
        {
            return Int32.TryParse(param, out int number);
        }
    }
}
