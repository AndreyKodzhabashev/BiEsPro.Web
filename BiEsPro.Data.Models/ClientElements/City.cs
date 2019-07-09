using BiEsPro.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BiEsPro.Data.Models.ClientElements
{
    public class City : BaseModel
    {
        public City()
        {
            this.Companies = new HashSet<ClientCompany>();
        }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        
        IEnumerable<ClientCompany> Companies { get; set; }

    }
}
