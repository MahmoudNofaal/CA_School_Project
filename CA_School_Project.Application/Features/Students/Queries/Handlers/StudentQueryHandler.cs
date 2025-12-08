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

public class StudentQueryHandler
   : ResponseHandler,
     IQueryHandler<GetStudentListQuery, Response<IEnumerable<GetStudentListResponse>>>,
     IQueryHandler<GetStudentByIdQuery, Response<GetSingleStudentReponse>>
{
   private readonly IStudentService _studentService;
   private readonly IMapper _mapper;

   public StudentQueryHandler(IStudentService studentService, IMapper mapper)
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

   public async Task<Response<GetSingleStudentReponse>> Handle
      (GetStudentByIdQuery request, CancellationToken cancellationToken)
   {
      var student = await _studentService.GetByIdWithIncludeAsync(request.Id);

      if (student is null)
      {
         return NotFound<GetSingleStudentReponse>($"Student with id: {request.Id} not found!");
      }

      var studentResponse = _mapper.Map<GetSingleStudentReponse>(student);

      return Success(studentResponse);
   }
}
