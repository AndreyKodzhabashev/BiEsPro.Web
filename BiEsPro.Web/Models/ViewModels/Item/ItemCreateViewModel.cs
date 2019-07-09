using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiEsPro.Web.Models.ViewModels.Item
{
    public class ItemsCreateViewModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }
        public IEnumerable<string> ColorName { get; set; }
        public IEnumerable<string> ItemTypeName { get; set; }

    }
}
