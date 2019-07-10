using BiEsPro.Data.Dtos.ClientCompanies;
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
    }
}
