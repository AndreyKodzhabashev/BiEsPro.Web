using BiEsPro.Data.Common.Models;
using System.Collections.Generic;

namespace BiEsPro.Data.Models.ItemElements
{
    public class Color : PropertyModel
    {
        public Color()
        {
            this.Items = new HashSet<Item>();
        }

        public IEnumerable<Item> Items { get; set; }
    }
}