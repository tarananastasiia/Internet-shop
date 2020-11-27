using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Validation.Param
{
    public class StringIsNotNull : IValidator
    {
        public ErrorsMessages Validation(string param, ErrorsMessages errors)
        {
            errors.IsNotError = true;
            if (String.IsNullOrEmpty(param))
            {
                errors.IsNotError = false;
                errors.Message = "Не може бути пусте значення";
            }
            return errors;
        }
    }
}
