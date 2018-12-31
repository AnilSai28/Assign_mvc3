using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace mvc_model_dal.Models
{
    public class loginviewmodel
    {
        [Display(Name ="login id")]
        [Required(ErrorMessage ="*")]
        public int loginid { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}