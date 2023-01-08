using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    public class ProductModel
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float SalePrice { get; set; }
        public int Quantity { get; set; }
        public string Images { get; set; }
        public int CategoryId { get; set; }
        public int WareHouseID { get; set; }
        public bool Status { get; set; }
        public string CategoryName { get; set; }
        public string WarehouseName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
