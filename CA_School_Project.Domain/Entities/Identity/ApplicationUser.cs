using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Domain.Entities.Identity;

public class ApplicationUser : IdentityUser<int>
{

   public string Address { get; set; }
   public string Country { get; set; }

}
