using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field can't blank")]
        public string Code { get; set; }
        [MaxLength(30, ErrorMessage = "Max of length is 30 characters")]
        [MinLength(2, ErrorMessage = "This field can't least 2 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Tax { get; set; }
        public float  Price { get; set; }
        // Foreign Key - tblCategory
        public int CategoryID { get; set; }
        public CategoryProduct Category { get; set; }
        // Foreign Key - tblWareHouse
        public int WareHouseID { get; set; }
        public WareHouse WareHouse { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
