using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.Students.Queries.Responses;
using CA_School_Project.Application.Wrappers;
using CA_School_Project.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.Students.Queries.Models;

public class GetStudentPaginatedListQuery : IQuery<PaginatedResult<GetStudentPaginatedListResponse>>
{
   public int PageNumber { get; set; } = 1;
   public int PageSize { get; set; } = 10;
   public StudentOrderingEnum OrderBy { get; set; }
   public string? Search { get; set; }


}
