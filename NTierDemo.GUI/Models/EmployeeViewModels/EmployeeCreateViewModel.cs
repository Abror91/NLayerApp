using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTierDemo.GUI.Models.EmployeeViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required]
        [Display(Name ="First Name")]
        [StringLength(25, ErrorMessage ="Employee First Name cannot be longer than 25 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(25, ErrorMessage = "Employee Last Name cannot be longer than 25 characters.")]
        public string LastName { get; set; }
        
        public int Age { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HiredDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal GrossSalary { get; set; }
    }
}