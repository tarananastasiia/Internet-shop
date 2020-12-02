using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Validation.Param
{
    public class StringValidator : IValidator
    {
        public ErrorsMessages Validate(string param, ErrorsMessages errors)
        {
            errors.IsNotError = true;

            return errors;
        }
    }
}
