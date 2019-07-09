using BiEsPro.Data.Common.Models;
using System.Collections.Generic;

namespace BiEsPro.Data.Models.ClientElements
{
    public class City : BaseModel
    {
        public City()
        {
            this.Companies = new HashSet<ClientCompany>();
        }

        public string Name { get; set; }
        
        IEnumerable<ClientCompany> Companies { get; set; }

    }
}
