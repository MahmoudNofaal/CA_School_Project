using AutoMapper;
using CA_School_Project.Application.Bases;
using CA_School_Project.Application.Bases.CQRS;
using CA_School_Project.Application.Features.Students.Commands.Models;
using CA_School_Project.Application.Resources;
using CA_School_Project.Application.Services.Abstractions;
using CA_School_Project.Domain.Entities;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.Students.Commands.Handlers;

public class StudentCommandHandler : ResponseHandler,
                                     ICommandHandler<AddStudentCommand, Response<string>>,
                                     ICommandHandler<EditStudentCommand, Response<string>>,
                                     ICommandHandler<DeleteStudentCommand, Response<string>>
                    
{
   private readonly IStudentService _studentService;
   private readonly IMapper _mapper;

   public StudentCommandHandler(IStudentService studentService,
                                IMapper mapper,
                                IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
   {
      this._studentService = studentService;
      this._mapper = mapper;
   }

   public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
   {
      // 1. Mapping between request and student entity
      var studentEntity = _mapper.Map<Student>(request);

      // 2. Add student using student service
      var result = await _studentService.AddAsync(studentEntity);

      // 3. Return response
      if (result)
      {
         return Success("Student is added successfully");
      }
      else
      {
         return BadRequest<string>("Failed to add student");
      }
   }

   public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
   {
      // 1. Check if id is exist or not
      var currentStudent = await _studentService.GetByIdAsync(request.Id);

      // 2. return NotFound
      if (currentStudent is null)
      {
         return NotFound<string>($"Student with that id: {request.Id} not found!");
      }

      // 3. Mapping between entity and request
      var studentToUpdate = _mapper.Map<Student>(request);

      // 4. call service for update
      var result = await _studentService.EditAsync(studentToUpdate);

      // 5. return response
      if (result)
      {
         return Success("Student edited successfully");
      }
      else
      {
         return BadRequest<string>();
      }
   }

   public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
   {
      // 1. Check if id is exist or not
      var currentStudent = await _studentService.GetByIdAsync(request.Id);

      // 2. return NotFound
      if (currentStudent is null)
      {
         return NotFound<string>($"Student with that id: {request.Id} not found!");
      }

      // 4. call service for update
      var result = await _studentService.DeleteAsync(currentStudent);

      // 5. return response
      if (result)
      {
         return Deleted<string>();
      }
      else
      {
         return BadRequest<string>();
      }
   }
}
