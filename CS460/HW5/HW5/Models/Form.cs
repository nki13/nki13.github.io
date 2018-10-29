using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Form
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        //label for uses this
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Phone, Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required, Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }

        [Required, Display(Name = "Unit Number")]
        public int UnitNumber { get; set; }

        [Required, Display(Name = "Explanation of Request, maintenance required or complaint. Please be specific")]
        public string Explanation { get; set; }

        public bool Permission { get; set; }
    }
}