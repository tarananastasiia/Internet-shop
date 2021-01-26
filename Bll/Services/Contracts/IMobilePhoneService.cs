using DTOs.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        PageDTO GetFiltering([FromQuery]PageRequestDto pageRequestDto);
        PageDTO GetSorting([FromQuery]SortingDto sortingDto);
    }
}
