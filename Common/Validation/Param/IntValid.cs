using System;
using System.Collections.Generic;
using System.Text;

namespace ExelImportUtil.Validation.Param
{
    public class IntValid : IValidator
    {
        public ErrorsMessages Validation(string param, ErrorsMessages errors)
        {
            //return Int32.TryParse(param, out int number);
            errors.IsNotError = true;
            if (param == null)
            {
                errors.IsNotError = false;
                errors.Message = "Не може бути пустим";
            }
            else if (Int32.TryParse(param, out int number) == false)
            {
                errors.Message = "Невірний формат";
                errors.IsNotError = false;
            }
            else if(Int32.Parse(param) < 0)
            {
                errors.IsNotError = false;
                errors.Message = "Не може бути менше нуля";
            }
            else if(Int32.Parse(param) > Int32.MaxValue)
            {
                errors.IsNotError = false;
                errors.Message = "Занадто велике число";
            }

            return errors;
        }


    }
}
