using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Validation.Param
{
    public class StringValid : IValidator
    {
        public ErrorsMessages Validation(string param, ErrorsMessages errors)
        {
            errors.IsNotError = true;

            return errors;
        }
        //public ErrorsMessages IsNotError(string param, ErrorsMessages errors)
        //{
        //}
    }
}
