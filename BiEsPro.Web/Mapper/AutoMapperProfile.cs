namespace BiEsPro.Web.Mapper
{
    using AutoMapper;
    using BiEsPro.Data.Dtos.ClientCompanies;
    using BiEsPro.Data.Models.ClientElements;
    using BiEsPro.Data.Models.ItemElements;
    using BiEsPro.Web.Models.BindingMoldels.ClientCompany;
    using BiEsPro.Web.Models.BindingMoldels.Item;
    using BiEsPro.Web.Models.ViewModels.Item;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<ItemCreateBindingModel, Item>();
            this.CreateMap<CreateClientCompanyBindingModel, ClientCompany>();
            this.CreateMap<ClientCompany, ClientCompanyDto>();
            this.CreateMap<ClientCompanyDto, EditClientCompanyBindingModel>();
            this.CreateMap<EditClientCompanyBindingModel, ClientCompany>();
            this.CreateMap<ClientCompanyDto, ItemDeleteViewModel>();
        }
    }
}
