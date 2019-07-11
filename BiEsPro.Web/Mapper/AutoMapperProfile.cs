using AutoMapper;
using BiEsPro.Data.Models.ItemElements;
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
        }
    }
}
