using AutoMapper;
using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.ApplicationUsers.Queries.Models;
using CA_School_Project.Application.Features.ApplicationUsers.Queries.Responses;
using CA_School_Project.Application.Resources;
using CA_School_Project.Application.Wrappers;
using CA_School_Project.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace CA_School_Project.Application.Features.ApplicationUsers.Queries.Handlers;

public class UserQueryHandler : ResponseHandler,
                                IQueryHandler<GetUserListQuery, PaginatedResult<GetUserListResponse>>,
                                IQueryHandler<GetUserByIdQuery, Response<GetSingleUserResponse>>
{
   private readonly IStringLocalizer<SharedResources> _stringLocalizer;
   private readonly IMapper _mapper;
   private readonly UserManager<ApplicationUser> _userManager;

   public UserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                           IMapper mapper,
                           UserManager<ApplicationUser> userManager) : base(stringLocalizer)
   {
      this._stringLocalizer = stringLocalizer;
      this._mapper = mapper;
      this._userManager = userManager;
   }

   public async Task<PaginatedResult<GetUserListResponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
   {
      var users = _userManager.Users.AsQueryable(); 
           
      var paginatedResult = await _mapper.ProjectTo<GetUserListResponse>(users)
                                         .ToPaginatedListAsync(request.PageNumber, request.PageSize);

      paginatedResult.Meta = new
      {
         Count = paginatedResult.Data.Count(),
      };

      return paginatedResult;
   }

   public async Task<Response<GetSingleUserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
   {
      var user = await _userManager.FindByIdAsync(request.Id.ToString());

      if (user == null)
      {
         return NotFound<GetSingleUserResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
      }

      var result = _mapper.Map<GetSingleUserResponse>(user);

      return Success(result);
   }
}
