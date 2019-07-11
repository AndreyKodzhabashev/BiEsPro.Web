using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiEsPro.Web.Models.BindingMoldels.ClientCompany
{
    public class ClientCompanyCreateBindingModel
    {
      
        public string Name { get; set; }

     
        public string CityId { get; set; }

      
        public string City { get; set; }

       
        public string Address { get; set; }

        
        public string PhoneNumber { get; set; }

      
        public string ContactPerson { get; set; }

       
        public string Owner { get; set; }

       
        public string VatRegistrationId { get; set; }

      
        public string VatRegistration { get; set; }

        public int Bulstat { get; set; }
               
        
        public string Email { get; set; }
              
       
        public string BIC { get; set; }

        
        public string IBAN { get; set; }
    }
}
