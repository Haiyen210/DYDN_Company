using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    [Table("tblOrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int? Id { get; set; }
        // Foreign Key - tblProduct
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        [DefaultValue(false)]
        public bool Status { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
