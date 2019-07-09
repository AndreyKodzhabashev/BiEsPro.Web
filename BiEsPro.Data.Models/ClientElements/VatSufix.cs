using BiEsPro.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BiEsPro.Data.Models.ClientElements
{
    //VAT registration type as BG, CZ (BULSTAT with)
    public class VatSufix : BaseModel
    {
        public VatSufix()
        {
            this.Companies = new HashSet<ClientCompany>();
        }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public IEnumerable<ClientCompany> Companies { get; set; }
    }
}
