using AutoMapper;
using BiEsPro.Data.Models.ClientElements;
using BiEsPro.Data.Models.ItemElements;
using BiEsPro.Services.ClientCompaniesService;
using BiEsPro.Web.Models.BindingMoldels.ClientCompany;
using BiEsPro.Web.Models.BindingMoldels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiEsPro.Web.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<ItemCreateBindingModel, Item>();
            this.CreateMap<CreateClientCompanyBindingModel, ClientCompany>();
            this.CreateMap<ClientCompany, ClientCompanyDto>();
            this.CreateMap<ClientCompanyDto, EditClientCompanyBindingModel>();
            this.CreateMap<EditClientCompanyBindingModel, ClientCompany>();
        }
    }
}
