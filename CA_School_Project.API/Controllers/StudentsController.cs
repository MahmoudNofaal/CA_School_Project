using CA_School_Project.Application.Features.Students.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CA_School_Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
   private readonly IMediator _mediator;

   public StudentsController(IMediator mediator)
	{
      this._mediator = mediator;
   }

   [HttpGet("list")]
   public async Task<IActionResult> GetStudentsListAsync()
   {
      var response = await _mediator.Send(new GetStudentListQuery());


      return Ok(response);
   }

}
