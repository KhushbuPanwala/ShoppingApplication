using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class ProductDetail
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductCode { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string ShippingNo { get; set; }
        [Required]
        public int SerialNo { get; set; }
        [Required]
        public string BatchNo { get; set; }
        [Required]
        public decimal MRP { get; set; }
        [Required]
        public int Quantity { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }

    }
}
