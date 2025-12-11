using CA_School_Project.API.Base;
using CA_School_Project.API.MetaData;
using CA_School_Project.Application.Features.Departments.Queries.Models;
using CA_School_Project.Application.Features.Students.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA_School_Project.API.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : AppControllerBase
{

   [HttpGet(DepartmentRoutes.GetById)]
   public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQuery query)
   {
      var response = await Mediator.Send(query);

      //return Ok(response);
      return NewResult(response);
   }

}
