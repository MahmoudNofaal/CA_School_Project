using CA_School_Project.Application.Services.Abstractions;
using CA_School_Project.Domain.Entities;
using CA_School_Project.Infrastructure.Abstractionss;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Services;

public class StudentService : IStudentService
{
   private readonly IStudentRepository _studentRepository;

   public StudentService(IStudentRepository studentRepository)
   {
      this._studentRepository = studentRepository;
   }

   public async Task<List<Student>> GetStudentsListAsync()
   {

      return await _studentRepository.GetStudentsListAsync();
   }
}
