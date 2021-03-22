using AutoMapper;
using Hahn.ApplicationProcess.February2021.Data.Core.Data;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Domain.Mapping
{
    public class AssetSaveProfile : Profile
    {
        public AssetSaveProfile()
        {
            CreateMap<SaveAssetDto, Asset>()
                .ForMember(dest => dest.AssetName,
                opt => opt.MapFrom(src => src.AssetName))
                .ForMember(dest => dest.EMailAdressOfDepartment,
                opt => opt.MapFrom(src => src.EMailAdressOfDepartment))
                .ForMember(dest => dest.CountryOfDepartment,
                opt => opt.MapFrom(src => src.CountryOfDepartment));
            //CreateMap<SaveAssetDto, Asset>();
        }
    }
}
