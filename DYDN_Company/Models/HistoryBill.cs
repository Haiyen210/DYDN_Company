using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    [Table("tblHistoryBill")]
    public class HistoryBill
    {
        [Key]
        public int Id { get; set; }
        // Foreign Key - tblBill
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        // Foreingn Key - tblOrder
        public ICollection<Order> Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
