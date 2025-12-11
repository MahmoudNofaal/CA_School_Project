using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.ApplicationUsers.Queries.Responses;
using CA_School_Project.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.ApplicationUsers.Queries.Models;

public class GetUserListQuery : IQuery<PaginatedResult<GetUserListResponse>>
{
   public int PageNumber { get; set; }
   public int PageSize { get; set; }

}
