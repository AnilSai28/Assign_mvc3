using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace mvc_model_dal.Models
{
    public class studentprojection
    {
        [Display(Name ="student id")]
        public int studentid { get; set; }
        [Display(Name ="studnet name")]
        public string studentname { get; set; }

        [Display(Name = "student gender")]
        public string studentgender { get; set; }

        [Display(Name = "student image")]
        public string studentimageaddress { get; set; }
    }
}