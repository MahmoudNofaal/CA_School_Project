using AutoMapper;
using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.Students.Queries.Models;
using CA_School_Project.Application.Features.Students.Queries.Responses;
using CA_School_Project.Application.Services.Abstractions;
using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.Students.Queries.Handlers;

public class GetStudentListQueryHandler
   : ResponseHandler, IQueryHandler<GetStudentListQuery, Response<IEnumerable<GetStudentListResponse>>>
{
   private readonly IStudentService _studentService;
   private readonly IMapper _mapper;

   public GetStudentListQueryHandler(IStudentService studentService, IMapper mapper)
   {
      this._studentService = studentService;
      this._mapper = mapper;
   }

   public async Task<Response<IEnumerable<GetStudentListResponse>>> Handle
      (GetStudentListQuery request, CancellationToken cancellationToken)
   {
      var studentList = await _studentService.GetStudentsListAsync();

      var studentListResponse = _mapper.Map<IEnumerable<GetStudentListResponse>>(studentList);

      return Success(studentListResponse);
   }

}
