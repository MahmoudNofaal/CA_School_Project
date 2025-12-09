using AutoMapper;
using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.Students.Queries.Models;
using CA_School_Project.Application.Features.Students.Queries.Responses;
using CA_School_Project.Application.Resources;
using CA_School_Project.Application.Services.Abstractions;
using CA_School_Project.Application.Wrappers;
using CA_School_Project.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CA_School_Project.Application.Features.Students.Queries.Handlers;

public class StudentQueryHandler : ResponseHandler,
                                   IQueryHandler<GetStudentListQuery, Response<IEnumerable<GetStudentListResponse>>>,
                                   IQueryHandler<GetStudentByIdQuery, Response<GetSingleStudentReponse>>,
                                   IQueryHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
{
   private readonly IStudentService _studentService;
   private readonly IMapper _mapper;
   private readonly IStringLocalizer<SharedResources> _stringLocalizer;

   public StudentQueryHandler(IStudentService studentService,
                              IMapper mapper,
                              IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
   {
      this._studentService = studentService;
      this._mapper = mapper;
      this._stringLocalizer = stringLocalizer;
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
         //return NotFound<GetSingleStudentReponse>($"Student with id: {request.Id} not found!");
         return NotFound<GetSingleStudentReponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
      }

      var studentResponse = _mapper.Map<GetSingleStudentReponse>(student);

      return Success(studentResponse);
   }

   public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle
      (GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
   {

      Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e
         => new GetStudentPaginatedListResponse(e.StudID, e.Name_En, e.Address, e.Department.DName_En);

      var queryable = _studentService.GetStudentsAsQueryable();

      var filterQuery = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);

      var paginatedResult = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

      return paginatedResult;
   }
}
