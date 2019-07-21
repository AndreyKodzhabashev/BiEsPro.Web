namespace BiEsPro.Data.Models.OrderElements
{
    using BiEsPro.Data.Common.Models;
    using System.Collections.Generic;

    public class PaymentType : PropertyModel
    {
        public PaymentType()
        {
            this.Orders = new HashSet<Order>();
        }

        public IEnumerable<Order> Orders { get; set; }
    }
}
