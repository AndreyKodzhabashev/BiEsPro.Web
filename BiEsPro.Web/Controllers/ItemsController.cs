using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiEsPro.Data;
using BiEsPro.Data.Models.ItemElements;
using BiEsPro.Services.ItemsService;
using BiEsPro.Web.Models.BindingMoldels.Item;
using AutoMapper;

namespace BiEsPro.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly BiEsProDbContext _context;
        private readonly IItemsService service;
        private readonly IMapper mapper;

        public ItemsController(BiEsProDbContext context,
                               IItemsService service,
                               IMapper mapper )
        {
            this._context = context;
            this.service = service;
            this.mapper = mapper;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var allItems = service.GetAllItemsAsync();
            return View(await allItems);
        }

        //// GET: Items/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var item = await _context.Items
        //        .Include(i => i.Color)
        //        .Include(i => i.ItemType)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        // GET: Items/Create
        public IActionResult Create()
        {

            ViewData["ColorId"] = new SelectList(service.GetAllItemColorsAsync().Result, "Id", "Name");
            ViewData["ItemTypeId"] = new SelectList(service.GetAllItemTypesAsync().Result, "Id", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Brand,Model,Code,ItemTypeId,ColorId,Price,Quantity")] ItemCreateBindingModel item)
        {
            if (ModelState.IsValid)
            {

                //var currentItem = new Item()
                //{
                //    Brand = item.Brand,
                //    Model = item.Model,
                //    Code = item.Code,
                //    ItemTypeId = item.ItemTypeId,
                //    ColorId = item.ColorId,
                //    Quantity = item.Quantity,
                //    Price = item.Price
                //};

                var currentItem = mapper.Map<Item>(item);

                await service.CreateItemAsync(currentItem);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(service.GetAllItemColorsAsync().Result, "Id", "Name", item.ColorId);
            ViewData["ItemTypeId"] = new SelectList(service.GetAllItemTypesAsync().Result, "Id", "Name", item.ItemTypeId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await service.FindItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(service.GetAllItemColorsAsync().Result, "Id", "Name", item.ColorId);
            ViewData["ItemTypeId"] = new SelectList(service.GetAllItemTypesAsync().Result, "Id", "Name", item.ItemTypeId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Brand,Model,Code,ItemTypeId,ColorId,Price,Quantity,Id,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!service.ItemExists(item.Id))
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

            ViewData["ColorId"] = new SelectList(service.GetAllItemColorsAsync().Result, "Id", "Name", item.ColorId);
            ViewData["ItemTypeId"] = new SelectList(service.GetAllItemTypesAsync().Result, "Id", "Name", item.ItemTypeId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Color)
                .Include(i => i.ItemType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await service.DeleteItemAsync(id);

            return RedirectToAction(nameof(Index));
        }

        //private bool ItemExists(string id)
        //{
        //    return _context.Items.Any(e => e.Id == id);
        //}
    }
}
