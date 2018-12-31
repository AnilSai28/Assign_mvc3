using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace mvc_model_dal.Models
{
    public class studentmodel
    {
        [Display(Name ="student id")]
        public int studentid { get; set; }

        [Display(Name ="student name")]
        [Required(ErrorMessage ="*")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="too short name")]
        public string studentname { get; set; }

        [Display(Name = "student email")]
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage ="invalid format")]
        public string studentemailid { get; set; }

        [Display(Name = "student password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string studentpassword { get; set; }

        [Display(Name = "student mobile")]
        [Required(ErrorMessage = "*")]
        [RegularExpression("^[7-9][0-9]{9}$",ErrorMessage ="invalid number")]
        public string studentmobile { get; set; }

        [Display(Name = "student city")]
        [Required(ErrorMessage = "*")]
        public string studentcity { get; set; }

        [Display(Name = "student gender")]
        [Required(ErrorMessage = "*")]
        public string studentgender { get; set; }

        public string studentimageaddress { get; set; }

        [Display(Name = "student image")]
        [Required(ErrorMessage = "*")]
        public HttpPostedFileBase studentimagefile { get; set; }
    }
}