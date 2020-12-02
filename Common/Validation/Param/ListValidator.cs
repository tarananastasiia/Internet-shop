using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExelImportUtil.Validation.Param
{

    public class ListValidator : IValidator
    {
        public ErrorsMessages Validate(string param, ErrorsMessages errors)
        {
            var urls = param.Split(" ").ToList();
            errors.IsNotError = true;
            if (urls.All(u => Uri.TryCreate(u, UriKind.Absolute, out Uri uriResult))==false)
            {
                errors.Message = "Нeвірний формат url-адреси";
                errors.IsNotError = false;
            }
            return errors;
        }

    }
}
