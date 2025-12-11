using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.ApplicationUsers.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.ApplicationUsers.Queries.Models;

public class GetUserByIdQuery : IQuery<Response<GetSingleUserResponse>>
{
   public GetUserByIdQuery(int id)
   {
      Id = id;
   }

   public int Id { get; set; }

}
