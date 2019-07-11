using BiEsPro.Data.Dtos.ClientCompanies;
using BiEsPro.Data.Models.ClientElements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BiEsPro.Services.ClientCompaniesService
{
    public interface IClientCompaniesService
    {
        Task<IEnumerable<AllClientCompaniesDto>> GetAllClientCompaniesAsync();

        Task<IEnumerable<CitiesDto>> GetAllCitiesAsync();

        Task<IEnumerable<VatSufixesDto>> GetAllVatSufixesAsync();

        Task CreateClientCompanyAsync(ClientCompany company);

        Task<ClientCompanyDto> FindClientCompanyAsync(string id);

        Task DeleteClientCompanyAsync(string id);

        bool ClientCompanyExists(string id);
    }
}
