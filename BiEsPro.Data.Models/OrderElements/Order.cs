namespace BiEsPro.Data.Models.OrderElements
{
    using BiEsPro.Data.Common.Models;
    using BiEsPro.Data.Models.ClientElements;
    using BiEsPro.Data.Models.ItemElements;
    using System;
    using System.Collections.Generic;

    public class Order : BaseModel
    {
        public Order()
        {
            this.Materials = new List<OrdersItems>();
        }

        public ClientCompany OrderOwner { get; set; }

        public DateTime OrderDate { get; set; }

        public bool CompanyTransport { get; set; }

        public bool CompanyInstallation { get; set; }

        public PaymentType PaymentType { get; set; }

        public IEnumerable<OrdersItems> Materials { get; set; }
    }
}
