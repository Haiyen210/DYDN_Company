using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    [Table("tblOrder")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "Max of length is 30 characters")]
        [MinLength(2, ErrorMessage = "This field can't least 2 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        // Foreign Key - tblAccount
        public int AccountID { get; set; }
        public AccountUser Account { get; set; }
        public int TotalQuantity { get; set; }
        public int TotalPrice { get; set; }
        [DefaultValue(false)]
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
