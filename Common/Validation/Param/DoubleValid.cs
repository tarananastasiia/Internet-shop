using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Validation.Param
{
    public class DoubleValid: IValidator
    {
        public ErrorsMessages Validation(string param,ErrorsMessages errors)
        {
            var d = Double.Parse(param);
            errors.IsNotError = true;
            if (Double.TryParse(param, out double number)==false&& Int32.TryParse(param, out int n)==false)
            {
                errors.IsNotError = false;
                errors.Message = "Невірний формат";
            }
            else if ( d < 0)
            {
                errors.Message = "Не може бути менше нуля";
                errors.IsNotError = false;
            }
            else if ( d > Double.MaxValue)
            {
                errors.Message = "Занадто велике число";
                errors.IsNotError = false;
            }
            if (param == null)
            {
                errors.IsNotError = false;
                errors.Message = "Не може бути пустим";
            }

            return errors;
        }

        
    }
}
