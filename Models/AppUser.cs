using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIN.Models
{
    public class AppUser:IdentityUser
    {
        [MaxLength(25), MinLength(0)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [MaxLength(25), MinLength(0)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [MaxLength(50), MinLength(0)]
        [Required]
        [Display(Name = "Adress")]
        public string Adress { get; set; }
        [Required]
        [Range(0, 10)]
        [MaxLength(11),MinLength(11)]
        [Display(Name = "OIB")]
        public int OIB { get; set; }
        [MaxLength(10), MinLength(0)]
        [Required]
        [Display(Name = "Education")]
        public string Education { get; set; }
        [Display(Name = "Birth date")]
        [DataType(DataType.Date), Required, DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime BirthDate { get; set; }
    }
}
