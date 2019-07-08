using BiEsPro.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BiEsPro.Data.Models.ItemElements
{
    public class Item : BaseModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Brand { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ItemTypeId { get; set; }
        public ItemType ItemType { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ColorId { get; set; }
        public Color Color { get; set; }

        [Column(TypeName = "decimal(16,8)")]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335", ParseLimitsInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(16,8)")]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335", ParseLimitsInInvariantCulture = true)]
        public decimal Quantity { get; set; }

        [NotMapped]
        public decimal TotalPrice => this.Quantity * this.Price;
    }
}
