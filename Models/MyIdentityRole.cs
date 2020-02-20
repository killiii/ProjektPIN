using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIN.Models
{
   
        public class MyIdentityRole : IdentityRole
        {
            [StringLength(120)]
            public string Description { get; set; }
        }
   
}
