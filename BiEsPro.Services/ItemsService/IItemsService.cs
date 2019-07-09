using BiEsPro.Data.Dtos;
using BiEsPro.Data.Dtos.Items;
using BiEsPro.Data.Models.ItemElements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiEsPro.Services.ItemsService
{
    public interface IItemsService
    {
        Task<IEnumerable<ColorsDto>> GetAllItemColorsAsync();

        Task<IEnumerable<ItemTypesDto>> GetAllItemTypesAsync();

        Task<IEnumerable<AlltemsDto>> GetAllItemsAsync();

        Task CreateItemAsync(Item item);

        Task<Item> FindItemAsync(string id);
        //Task<ItemDetailsDto> GetItemDetails();

        Task DeleteItemAsync(string id);

        bool ItemExists(string id);
    }
}
