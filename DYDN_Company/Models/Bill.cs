using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    [Table("tblBill")]
    public class Bill
    {
        [Key]
        public int? Id { get; set; }
        // Foreign Key - tblOrder
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public float TotalPrice { get; set; }
        public int Tax { get; set; }
        [DefaultValue(false)]
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
    }
}
