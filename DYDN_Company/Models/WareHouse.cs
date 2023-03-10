using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    [Table("tblWareHouse")]
    public class WareHouse
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "This field can't blank")]
        public string Code { get; set; }
        [MaxLength(250, ErrorMessage = "Max of length is 250 characters")]
        [MinLength(2, ErrorMessage = "This field can't least 2 characters")]
        public string Name { get; set; }
        [DefaultValue(true)]
        public byte Status { get; set; }
        public int FactoryID { get; set; }
        public Factory Factorys { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    public class WareHouseDisplay : WareHouse
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public float ProductSalePrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductImages { get; set; }
        public bool ProductStatus { get; set; }
    }
    public class WareHouseDisplayFactory : WareHouse
    {
        public string FactoryName { get; set; }
    }

}
