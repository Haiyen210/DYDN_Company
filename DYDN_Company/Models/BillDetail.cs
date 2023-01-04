using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    [Table("tblBillDetail")]
    public class BillDetail
    {
        [Key]
        public int Id { get; set; }
        // Foreign Key - tblBill
        public int BillID { get; set; }
        public Bill Bill { get; set; }
        // Foreign Key - tblOrderDetail
        public int OrderDetailID { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
