using BiEsPro.Data.Common.Models;
using System.Collections.Generic;

namespace BiEsPro.Data.Models.ClientElements
{
    //VAT registration type as BG, CZ (BULSTAT with)
    public class VatSufix : BaseModel
    {
        public VatSufix()
        {
            this.Companies = new HashSet<ClientCompany>();
        }

        public string Name { get; set; }

        IEnumerable<ClientCompany> Companies { get; set; }
    }
}
