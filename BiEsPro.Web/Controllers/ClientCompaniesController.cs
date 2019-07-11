using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiEsPro.Data;
using BiEsPro.Data.Models.ClientElements;
using BiEsPro.Services.ClientCompaniesService;
using BiEsPro.Web.Models.BindingMoldels.ClientCompany;
using AutoMapper;

namespace BiEsPro.Web.Controllers
{
    public class ClientCompaniesController : Controller
    {
        private readonly BiEsProDbContext _context;
        private readonly IClientCompaniesService service;
        private readonly IMapper mapper;

        public ClientCompaniesController(BiEsProDbContext context, 
                                         IClientCompaniesService service,
                                         IMapper mapper)
        {
            _context = context;
            this.service = service;
            this.mapper = mapper;
        }

        // GET: ClientCompanies
        public async Task<IActionResult> Index()
        {
            var result = service.GetAllClientCompaniesAsync();
            return View(await result);
        }

        //// GET: ClientCompanies/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var clientCompany = await _context.ClientCompanies
        //        .Include(c => c.City)
        //        .Include(c => c.VatRegistration)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (clientCompany == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(clientCompany);
        //}

        // GET: ClientCompanies/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(service.GetAllCitiesAsync().Result, "Id", "Name");
            ViewData["VatRegistrationId"] = new SelectList(service.GetAllVatSufixesAsync().Result, "Id", "Name");
            return View();
        }

        // POST: ClientCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CityId,Address,PhoneNumber,ContactPerson,Owner,VatRegistrationId,Bulstat,Email,BIC,IBAN,Id")] CreateClientCompanyBindingModel clientCompany)
        {
            if (ModelState.IsValid)
            {
                var currentCompany = mapper.Map<ClientCompany>(clientCompany);
                await service.CreateClientCompanyAsync(currentCompany);
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(service.GetAllCitiesAsync().Result, "Id", "Name", clientCompany.CityId);
            ViewData["VatRegistrationId"] = new SelectList(service.GetAllVatSufixesAsync().Result, "Id", "Name", clientCompany.VatRegistrationId);
            return View(clientCompany);
        }

        // GET: ClientCompanies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCompanyDto = await service.FindClientCompanyAsync(id);
            if (clientCompanyDto == null)
            {
                return NotFound();
            }
            var clientCompany = mapper.Map<EditClientCompanyBindingModel>(clientCompanyDto);

            ViewData["CityId"] = new SelectList(service.GetAllCitiesAsync().Result, "Id", "Name", clientCompany.CityId);
            ViewData["VatRegistrationId"] = new SelectList(service.GetAllVatSufixesAsync().Result, "Id", "Name", clientCompany.VatRegistrationId);
            return View(clientCompany);
        }

        // POST: ClientCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,CityId,Address,PhoneNumber,ContactPerson,Owner,VatRegistrationId,Bulstat,Email,BIC,IBAN,Id")] EditClientCompanyBindingModel clientCompany)
        {
            if (id != clientCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentCompany = mapper.Map<ClientCompany>(clientCompany);

                    _context.Update(currentCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!service.ClientCompanyExists(clientCompany.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", clientCompany.CityId);
            ViewData["VatRegistrationId"] = new SelectList(_context.VatSufixes, "Id", "Id", clientCompany.VatRegistrationId);
            return View(clientCompany);
        }

        // GET: ClientCompanies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCompany = await _context.ClientCompanies
                .Include(c => c.City)
                .Include(c => c.VatRegistration)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientCompany == null)
            {
                return NotFound();
            }

            return View(clientCompany);
        }

        // POST: ClientCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await service.DeleteClientCompanyAsync(id);

            return RedirectToAction(nameof(Index));
        }

        //private bool ClientCompanyExists(string id)
        //{
        //    return _context.ClientCompanies.Any(e => e.Id == id);
        //}
    }
}
