using BiEsPro.Data.Models.ItemElements;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiEsPro.Data.Models.OrderElements
{
    public class OrdersItems
    {
        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string ItemId { get; set; }

        public Item Item { get; set; }
    }
}
