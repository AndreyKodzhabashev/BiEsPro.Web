using BiEsPro.Data.Common.Models;
using System.Collections.Generic;

namespace BiEsPro.Data.Models.ItemElements
{
    public class ItemType : PropertyModel
    {
        public ItemType()
        {
            this.Items = new HashSet<Item>();
        }

        public IEnumerable<Item> Items { get; set; }
    }
}