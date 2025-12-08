using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.Students.Queries.Responses;
using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.Students.Queries.Models;

public class GetStudentListQuery : IQuery<Response<IEnumerable<GetStudentListResponse>>>
{


}
