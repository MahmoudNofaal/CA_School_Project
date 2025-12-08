using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;

namespace CA_School_Project.Application.Features.Students.Commands.Models;

public class DeleteStudentCommand : ICommand<Response<string>>
{
   public int Id { get; set; }

	public DeleteStudentCommand(int id)
	{
		this.Id = id;
   }

}
