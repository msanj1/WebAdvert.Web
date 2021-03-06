﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertApi.Models;
using AdvertApi.ServiceClients;
using AutoMapper;
using WebAdvert.Web.Models;
using WebAdvert.Web.Models.AdvertManagement;
using WebAdvert.Web.Models.Home;

namespace WebAdvert.Web.Classes
{
    public class WebsiteProfile: Profile
    {
        public WebsiteProfile()
        {
            CreateMap<CreateAdvertModel, CreateAdvertViewModel>().ReverseMap();
            CreateMap<AdvertModel, Advertisement>().ReverseMap();
            CreateMap<CreateAdvertModel, AdvertModel>();
            CreateMap<CreateAdvertResponse, AdvertResponse>();
            CreateMap<ConfirmAdvertRequest, ConfirmAdvertModel>();
            CreateMap<Advertisement, IndexViewModel>()
                .ForMember(
                    dest => dest.Title, src => src.MapFrom(field => field.Title))
                .ForMember(dest => dest.Image, src => src.MapFrom(field => field.FilePath));

            CreateMap<AdvertType, SearchViewModel>()
                .ForMember(
                    dest => dest.Id, src => src.MapFrom(field => field.Id))
                .ForMember(
                    dest => dest.Title, src => src.MapFrom(field => field.Title));
        }
    }
}
