using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ExelImportUtil.Validation.Param
{

    public class ListValid : IValidator
    {
        public bool IsValid(string param)
        {
            var urls = param.Split(" ").ToList();
            bool res = urls.All(u => Uri.TryCreate(u, UriKind.Absolute, out Uri uriResult));
            return res;
        }

    }
}
