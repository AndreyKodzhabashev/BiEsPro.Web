using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiEsPro.Data.Dtos.ClientCompanies
{
    public class AllClientCompaniesDto
    {
        public string Id { get; set; }

        [Display(Name = "Company")]
        public string Name { get; set; }
                      
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Contact person")]
        public string ContactPerson { get; set; }

        [Display (Name = "МОЛ")]
        public string Owner { get; set; }

        [Display(Name = "VAT Registered")]
        public bool IsVatReg { get; set; }

        [Display(Name = "BULSTAT/EGN")]
        public int Bulstat { get; set; }

        [Display(Name = "EIK number")]
        public string Eik { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Full address")]
        public string CompleteAddress { get; set; }


        public string BIC { get; set; }


        public string IBAN { get; set; }
    }
}
