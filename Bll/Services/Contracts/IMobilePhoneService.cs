using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.Services.Contracts
{
    public interface IMobilePhoneService
    {
        void UploadFile(byte[] bin);
        List<MobilePhones> GetMobilePhone();
    }
}
