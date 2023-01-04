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
        public int Id { get; set; }
        // Foreign Key - tblOrder
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public float TotalPrice { get; set; }
        [DefaultValue(false)]
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
