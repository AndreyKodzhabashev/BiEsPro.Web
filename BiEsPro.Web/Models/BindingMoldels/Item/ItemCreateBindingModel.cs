using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiEsPro.Web.Models.BindingMoldels.Item
{
    public class ItemCreateBindingModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Brand { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ItemTypeId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ColorId { get; set; }

        [Column(TypeName = "decimal(16,8)")]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335", ParseLimitsInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(16,8)")]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335", ParseLimitsInInvariantCulture = true)]
        public decimal Quantity { get; set; }
    }
}
