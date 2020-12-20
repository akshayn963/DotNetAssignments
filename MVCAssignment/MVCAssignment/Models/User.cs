using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace MVCAssignment.Models
{
    public class User
    {
        [Key]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter field")]
        public string loginName { set; get; }

        [MaxLength(10), MinLength(4)]
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string password { set; get; }

        [MaxLength(10), MinLength(4)]
        [Required(ErrorMessage = "Please enter Field")]
        [DataType(DataType.Text)]
        public string fullName { set; get; }

        [Required(ErrorMessage = "Please enter Field")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string emailId { set; get; }

        public int cityId { set; get; }

        [Required(ErrorMessage = "Please enter Field")]
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$", 
            ErrorMessage = "Not a valid Phone number")]

        public string phone { set; get; }

        public IEnumerable<SelectListItem> cities { get; set; }
        public bool isActive { get; set; }
    }
}