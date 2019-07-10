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

namespace BiEsPro.Web.Controllers
{
    public class ClientCompaniesController : Controller
    {
        private readonly BiEsProDbContext _context;
        private readonly IClientCompaniesService service;

        public ClientCompaniesController(BiEsProDbContext context, IClientCompaniesService service)
        {
            _context = context;
            this.service = service;
        }

        // GET: ClientCompanies
        public async Task<IActionResult> Index()
        {
            var result = service.GetAllClientCompaniesAsync();
            return View(await result);
        }

        // GET: ClientCompanies/Details/5
        public async Task<IActionResult> Details(string id)
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
        public async Task<IActionResult> Create([Bind("Name,CityId,Address,PhoneNumber,ContactPerson,Owner,VatRegistrationId,Bulstat,Email,BIC,IBAN,Id,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] ClientCompany clientCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", clientCompany.CityId);
            ViewData["VatRegistrationId"] = new SelectList(_context.VatSufixes, "Id", "Id", clientCompany.VatRegistrationId);
            return View(clientCompany);
        }

        // GET: ClientCompanies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCompany = await _context.ClientCompanies.FindAsync(id);
            if (clientCompany == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", clientCompany.CityId);
            ViewData["VatRegistrationId"] = new SelectList(_context.VatSufixes, "Id", "Id", clientCompany.VatRegistrationId);
            return View(clientCompany);
        }

        // POST: ClientCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,CityId,Address,PhoneNumber,ContactPerson,Owner,VatRegistrationId,Bulstat,Email,BIC,IBAN,Id,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] ClientCompany clientCompany)
        {
            if (id != clientCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientCompanyExists(clientCompany.Id))
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
            var clientCompany = await _context.ClientCompanies.FindAsync(id);
            _context.ClientCompanies.Remove(clientCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientCompanyExists(string id)
        {
            return _context.ClientCompanies.Any(e => e.Id == id);
        }
    }
}
