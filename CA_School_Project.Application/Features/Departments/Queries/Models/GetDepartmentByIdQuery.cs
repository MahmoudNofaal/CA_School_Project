using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.Departments.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.Departments.Queries.Models;

public class GetDepartmentByIdQuery : IQuery<Response<GetSingleDepartmentResponse>>
{
   public int Id { get; set; }
	public int StudentPageNumber { get; set; }
	public int StudentPageSize { get; set; }

}
