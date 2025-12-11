using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.ApplicationUsers.Queries.Responses;

public class GetUserListResponse
{
   public string FullName { get; set; }
   public string Email { get; set; }

   public string? Address { get; set; }
   public string? Country { get; set; }

}
