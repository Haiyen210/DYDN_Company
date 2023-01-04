using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field can't blank")]
        public string Code { get; set; }
        [MaxLength(30, ErrorMessage = "Max of length is 30 characters")]
        [MinLength(2, ErrorMessage = "This field can't least 2 characters")]
        public string Name { get; set; }
        [DefaultValue(true)]
        public bool Gender { get; set; }
        [Required(ErrorMessage = "This field is REQUIRED")]
        public DateTime Birthday { get; set; }
        [MaxLength(50, ErrorMessage = "Up to 50 characters")]
        [Required(ErrorMessage = "This field is REQUIRED")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This field is REQUIRED")]
        [RegularExpression(@"^([\w-\.]{2,30})@([\w]{2,12})(\.)([\w]{2,4})$", ErrorMessage = "Email is INVALID")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Number phone is REQUIRED")]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", ErrorMessage = "Phone is INVALID")]
        public string Phone { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
        [Required(ErrorMessage = "This field can't empty")]
        [MinLength(8, ErrorMessage = "Password must be at least 2 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage ="This field is not empty")]
        public string Role { get; set; }
        // Foreign Key - tblDepartment
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
