using ExelImportUtil.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExelImportUtil
{
    public interface IValidator
    {
        ErrorsMessages Validate(string param,ErrorsMessages errors); 
    }
}
