using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.Services.Contracts
{
    public interface IEpplusImportFile
    {
        List<T> GetEntityExel<T>(byte[] bin, IFormFile files) where T : new();
    }
}
