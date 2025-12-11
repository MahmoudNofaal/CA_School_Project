using AutoMapper;
using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.ApplicationUsers.Commands.Models;
using CA_School_Project.Application.Resources;
using CA_School_Project.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.ApplicationUsers.Commands.Handlers;

public class ApplicationUserCommandHandler : ResponseHandler,
                                  ICommandHandler<AddApplicationUserCommand, Response<string>>
{
   private readonly IStringLocalizer<SharedResources> _stringLocalizer;
   private readonly IMapper _mapper;
   private readonly UserManager<ApplicationUser> _userManager;

   public ApplicationUserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                        IMapper mapper,
                                        UserManager<ApplicationUser> userManager) : base(stringLocalizer)
	{
      this._stringLocalizer = stringLocalizer;
      this._mapper = mapper;
      this._userManager = userManager;
   }

   public async Task<Response<string>> Handle(AddApplicationUserCommand request, CancellationToken cancellationToken)
   {
      // 1. Check if email is exists
      var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);

      // 2. If exists unprocessable action
      if (userWithSameEmail != null)
      {
         return UnprocessableEntity<string>("Email is already exists!");
      }

      // 3. Mapping to applicationUser
      var userToCreate = _mapper.Map<ApplicationUser>(request);

      // 4. Create new user
      var resultOfCreate = await _userManager.CreateAsync(userToCreate, request.Password);

      // 5. Check result if true
      if (!resultOfCreate.Succeeded)
      {
         return BadRequest<string>("Failed to create user");
      }

      // 6. Return success
      return Created("User created successfully.");
   }

}
