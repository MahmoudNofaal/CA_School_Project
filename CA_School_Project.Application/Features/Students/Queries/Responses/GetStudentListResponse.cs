using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CA_School_Project.Application.Features.Students.Queries.Responses;

public class GetStudentListResponse
{
   public int StudID { get; set; }

   public string? Name { get; set; }
   public string? Address { get; set; }
   public string? DepartmentName { get; set; }

}
