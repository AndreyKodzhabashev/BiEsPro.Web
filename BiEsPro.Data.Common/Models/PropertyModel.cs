using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BiEsPro.Data.Common.Models
{
    public class PropertyModel : BaseModel
    {
        [Required(AllowEmptyStrings = false)]
        [Index]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Index]
        public string Name { get; set; }
    }
}
