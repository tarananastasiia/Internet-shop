using DTOs.ViewModels;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll.Services.Contracts
{
    public interface IMobilePhoneService
    {
        void UploadFile(byte[] bin);
        PageDTO GetMobilePhone(int pageNumber, int pageSize);
        IQueryable<MobilePhones> GetFilteringBySort(int minPrice, int maxPrice);
    }
}
