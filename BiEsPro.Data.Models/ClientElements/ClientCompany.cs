using BiEsPro.Data.Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiEsPro.Data.Models.ClientElements
{
    public class ClientCompany : BaseModel
    {
        public string Name { get; set; }

        public City City { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string ContactPerson { get; set; }

        public string Owner { get; set; }

        public VatSufix VatRegistration { get; set; }

        public int Bulstat { get; set; }

        [NotMapped]
        public string Eik => this.VatRegistration.Name + this.Bulstat.ToString();

        public string Email { get; set; }

        [NotMapped]
        public string CompleteAddress => this.City + this.Address;

        public string BIC { get; set; }

        public string IBAN { get; set; }

    }
}
