using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;

namespace CA_School_Project.Application.Features.Students.Commands.Models;

public class EditStudentCommand : ICommand<Response<string>>
{
   public int Id { get; set; }
   public string Name { get; set; }
   public string Address { get; set; }

   public string? Phone { get; set; }

   public int DepartmentId { get; set; }

}
