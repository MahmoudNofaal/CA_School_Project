using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.Students.Commands.Models;

public class AddStudentCommand : ICommand<Response<string>>
{
   public string Name { get; set; }
   public string Address { get; set; }

   public string? Phone { get; set; }

   public int DepartmentId { get; set; }

}
