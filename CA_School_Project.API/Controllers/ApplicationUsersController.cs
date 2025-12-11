using CA_School_Project.API.Base;
using CA_School_Project.API.MetaData;
using CA_School_Project.Application.Features.ApplicationUsers.Commands.Models;
using CA_School_Project.Application.Features.ApplicationUsers.Queries.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA_School_Project.API.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class ApplicationUsersController : AppControllerBase
{

   [HttpPost(ApplicationUserRoutes.Create)]
   public async Task<IActionResult> Create([FromBody] AddApplicationUserCommand command)
   {
      var response = await Mediator.Send(command);

      //return Ok(response);
      return NewResult(response);
   }

   [HttpGet(ApplicationUserRoutes.Paginated)]
   public async Task<IActionResult> Paginated([FromQuery] GetUserListQuery query)
   {
      var response = await Mediator.Send(query);

      //return Ok(response);
      return Ok(response);
   }

   [HttpGet(ApplicationUserRoutes.GetById)]
   public async Task<IActionResult> GetUserById([FromRoute] int id)
   {
      var response = await Mediator.Send(new GetUserByIdQuery(id));

      //return Ok(response);
      return NewResult(response);
   }

}
