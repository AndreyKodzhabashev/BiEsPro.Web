using BiEsPro.Data.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiEsPro.Data.Models.ClientElements
{
    public class ClientCompany : BaseModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string CityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public City City { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ContactPerson { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Owner { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string VatRegistrationId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public VatSufix VatRegistration { get; set; }

        public int Bulstat { get; set; }

        [NotMapped]
        public string Eik => this.VatRegistration.Name + this.Bulstat.ToString();

        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [NotMapped]
        public string CompleteAddress => this.City + this.Address;

        [Required(AllowEmptyStrings = false)]
        public string BIC { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string IBAN { get; set; }

    }
}
