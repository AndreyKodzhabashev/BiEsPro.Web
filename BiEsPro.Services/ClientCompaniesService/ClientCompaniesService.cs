using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BiEsPro.Data;
using BiEsPro.Data.Dtos.ClientCompanies;
using BiEsPro.Data.Models.ClientElements;

namespace BiEsPro.Services.ClientCompaniesService
{
    public class ClientCompaniesService : IClientCompaniesService
    {
        private readonly BiEsProDbContext context;
        private readonly IMapper mapper;

        public ClientCompaniesService(BiEsProDbContext context,
                                      IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task CreateClientCompanyAsync(ClientCompany company)
        {
            await context.AddAsync(company);
            await context.SaveChangesAsync();
        }

        public async Task DeleteClientCompanyAsync(string id)
        {
            var company = await context.ClientCompanies.FindAsync(id);
            company.IsDeleted = true;
            company.DeletedOn = DateTime.UtcNow;
            context.ClientCompanies.Update(company);
            await context.SaveChangesAsync();
        }

        public async Task<ClientCompanyDto> FindClientCompanyAsync(string id)
        {
            var company = context.ClientCompanies.Include(x => x.City).Include(x => x.VatRegistration).FirstOrDefault(x => x.Id == id);
            if (company == null)
            {
                return null;
            }
            ;
            var result = new ClientCompanyDto {
            Address = company.Address,
            BIC = company.BIC,
            Bulstat = company.Bulstat,
            City = company.City.Name,
            Name = company.Name,
            CityId = company.CityId,
            ContactPerson = company.ContactPerson,
            Email = company.Email,
            IBAN = company.IBAN,
            Owner = company.Owner,
            PhoneNumber = company.PhoneNumber,
            VatRegistrationId = company.VatRegistrationId,
            VatRegistration = company.VatRegistration.Name};

            return result;

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
                                            IsVatReg = (x.VatRegistration.Name == ServicesConstants.NotRegistered) == false,
                                            Name = x.Name,
                                            Owner = x.Owner,
                                            PhoneNumber = x.PhoneNumber,
                                            Eik = x.VatRegistration.Name
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

        public bool ClientCompanyExists(string id)
        {
            var result = context.ClientCompanies.Any(x => x.Id == id && x.IsDeleted == false);
            return result;
        }
    }
}
