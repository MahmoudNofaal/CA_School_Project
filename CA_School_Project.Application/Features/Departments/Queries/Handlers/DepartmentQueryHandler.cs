using AutoMapper;
using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.Departments.Queries.Models;
using CA_School_Project.Application.Features.Departments.Queries.Responses;
using CA_School_Project.Application.Resources;
using CA_School_Project.Application.Services.Abstractions;
using CA_School_Project.Application.Wrappers;
using CA_School_Project.Domain.Entities;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace CA_School_Project.Application.Features.Departments.Queries.Handlers;

public class DepartmentQueryHandler : ResponseHandler,
                                      IQueryHandler<GetDepartmentByIdQuery, Response<GetSingleDepartmentResponse>>
{
   private readonly IStringLocalizer<SharedResources> _stringLocalizer;
   private readonly IDepartmentService _departmentService;
   private readonly IMapper _mapper;
   private readonly IStudentService _studentService;

   public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                 IDepartmentService departmentService,
                                 IMapper mapper,
                                 IStudentService studentService) : base(stringLocalizer)
   {
      this._stringLocalizer = stringLocalizer;
      this._departmentService = departmentService;
      this._mapper = mapper;
      this._studentService = studentService;
   }

   public async Task<Response<GetSingleDepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
   {
      // 1. Get data from database
      var department = await _departmentService.GetByIdWithIncludeAsync(request.Id);

      // 2. Check on id
      if (department == null)
      {
         return NotFound<GetSingleDepartmentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
      }

      // 3. Map data to response
      var departmentReponse = _mapper.Map<GetSingleDepartmentResponse>(department);

      // 4. Pagination: Get Student PaginatedList
      Expression<Func<Student, StudentReponse>> expression = e => new StudentReponse(e.Id, e.Localize(e.Name_Ar, e.Name_En));
      var studentQuerable = _studentService.GetStudentsByDepartmentIdAsQueryable(request.Id);
      var paginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);

      departmentReponse.StudentsList = paginatedList;

      // 5. Return response
      return Success(departmentReponse);
   }

}
