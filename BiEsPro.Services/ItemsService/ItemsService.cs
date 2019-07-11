using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BiEsPro.Data;
using BiEsPro.Data.Dtos.Items;
using BiEsPro.Data.Models.ItemElements;

namespace BiEsPro.Services.ItemsService
{
    public class ItemsService : IItemsService
    {
        private readonly BiEsProDbContext context;

        public ItemsService(BiEsProDbContext context)
        {
            this.context = context;
        }

        public async Task CreateItemAsync(Item item)
        {
            await context.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(string id)
        {
            var item = await this.FindItemAsync(id);
            item.IsDeleted = true;
            item.DeletedOn = DateTime.UtcNow;
            context.Items.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task<Item> FindItemAsync(string id)
        {
            var item = await context.Items.FindAsync(id);
            return item;
        }

        public async Task<IEnumerable<ColorsDto>> GetAllItemColorsAsync()
        {
            var colors = Task.Run(() => context
                            .Colors
                            .Where(x => x.IsDeleted == false)
                            .Select(x => new ColorsDto
                            {
                                Id = x.Id,
                                Name = x.Name
                            })
                            .ToList());

            return await colors;
        }

        public async Task<IEnumerable<AlltemsDto>> GetAllItemsAsync()
        {
            var allItems = Task.Run(() => context
                                    .Items
                                    .Where(x=>x.IsDeleted == false)
                                    .Include(i => i.Color)
                                    .Include(i => i.ItemType)
                                    .Select(x => new AlltemsDto
                                    {
                                        Id = x.Id,
                                        Brand = x.Brand,
                                        Code = x.Code,
                                        Model = x.Model,
                                        Quantity = x.Quantity
                                    })
                                    .ToList());

            return await allItems;
        }

        public async Task<IEnumerable<ItemTypesDto>> GetAllItemTypesAsync()
        {
            var itemTypes = Task.Run(() => context
                            .ItemTypes
                            .Where(x => x.IsDeleted == false)
                            .Select(x => new ItemTypesDto
                            {
                                Id = x.Id,
                                Name = x.Name
                            })
                            .ToList());

            return await itemTypes;
        }

        public bool ItemExists(string id)
        {
            var result = context.Items.Any(x => x.Id == id && x.IsDeleted == false);
            return result;
        }
    }
}
