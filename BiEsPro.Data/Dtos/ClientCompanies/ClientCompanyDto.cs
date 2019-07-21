namespace BiEsPro.Data.Dtos.ClientCompanies
{
    using System.ComponentModel.DataAnnotations;

    public class ClientCompanyDto
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string CityId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }

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
        public string VatRegistration { get; set; }

        public int Bulstat { get; set; }


        public string Eik => VatRegistration + Bulstat;

        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }


        public string CompleteAddress => City + Address;

        [Required(AllowEmptyStrings = false)]
        public string BIC { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string IBAN { get; set; }
    }
}
