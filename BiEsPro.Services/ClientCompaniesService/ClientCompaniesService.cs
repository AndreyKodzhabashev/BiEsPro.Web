using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiEsPro.Data;
using BiEsPro.Data.Dtos.ClientCompanies;
using BiEsPro.Data.Models.ClientElements;

namespace BiEsPro.Services.ClientCompaniesService
{
    public class ClientCompaniesService : IClientCompaniesService
    {
        private readonly BiEsProDbContext context;

        public ClientCompaniesService(BiEsProDbContext context)
        {
            this.context = context;
        }

        public async Task CreateClientCompanyAsync(ClientCompany company)
        {
            await context.AddAsync(company);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CitiesDto>> GetAllCitiesAsync()
        {
            var result = Task.Run(() => context
                                       .Cities
                                       .Where(x => x.IsDeleted == false)
                                       .Select(x => new CitiesDto
                                       {
                                           Id = x.Id,
                                           Name = x.Name
                                       })
                                       .ToList());

            return await result;
        }

        public async Task<IEnumerable<AllClientCompaniesDto>> GetAllClientCompaniesAsync()
        {
            var result = Task.Run(() => context
                                        .ClientCompanies
                                        .Where(x => x.IsDeleted == false)
                                        .Select(x => new AllClientCompaniesDto
                                        {
                                            Id = x.Id,
                                            BIC = x.BIC,
                                            Bulstat = x.Bulstat,
                                            ContactPerson = x.ContactPerson,
                                            CompleteAddress = x.CompleteAddress,
                                            Email = x.Email,
                                            IBAN = x.IBAN,
                                            IsVatReg = (x.VatRegistration.Name == ServicesConstants.NotRegistered) ? true : false,
                                            Name = x.Name,
                                            Owner = x.Owner,
                                            PhoneNumber = x.PhoneNumber,
                                            Eik = x.VatRegistration.Name == ServicesConstants.NotRegistered ? "N/A" : x.Eik
                                        }).ToList());

            return await result;
        }

        public async Task<IEnumerable<VatSufixesDto>> GetAllVatSufixesAsync()
        {
            var result = Task.Run(() => context
                                        .VatSufixes
                                        .Where(x => x.IsDeleted == false)
                                        .Select(x => new VatSufixesDto
                                        {
                                            Id = x.Id,
                                            Name = x.Name
                                        })
                                        .ToList());

            return await result;
        }
    }
}
