using AutoMapper;
using DTOs.ViewModels;
using SiteMy.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ExelImportUtil;
using System.Linq;
using Dal.Models;

namespace Bll
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MobilePhonesExcelDTO, MobilePhones>()
                .ForMember(x => x.LinkToPhotos, f => f.MapFrom(x => x.LinkToPhoto.Select(link => new LinkToPhoto() { Link = link }).ToList()));

            CreateMap<PlumbingExcelDTO, Plumbing>();

        }
    }
}
