using BiEsPro.Data.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiEsPro.Data.Models
{
    public class BiEsProUser : IdentityUser, IDeletableEntity, IAuditInfo
    {
        public BiEsProUser()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        //private const string ErrorMessageForUCN = "The {0} must be at least {2} and at max {1} characters long.";
        private const string ErrorMessageForUCN = "The UCN(EGN) must be exactly 10 ";
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        [Display(Name = "UCN")]
        public string Ucn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

    }
}
