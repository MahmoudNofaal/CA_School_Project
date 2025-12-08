using CA_School_Project.Application.Services.Abstractions;
using CA_School_Project.Domain.Entities;
using CA_School_Project.Infrastructure.Repositories.Abstractionss;
using Microsoft.EntityFrameworkCore;
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

   public async Task<bool> AddAsync(Student student)
   {
      // add student
      await _studentRepository.AddAsync(student);

      return true;
   }

   public async Task<bool> DeleteAsync(Student student)
   {
      var transactions = _studentRepository.BeginTransaction();

      try
      {
         // delete student
         await _studentRepository.DeleteAsync(student);
         await transactions.CommitAsync();
         return true;
      }
      catch
      {
         await transactions.RollbackAsync();
         return false;
      }
   }

   public async Task<bool> EditAsync(Student student)
   {
      // add student
      await _studentRepository.UpdateAsync(student);

      return true;
   }

   public async Task<Student> GetByIdAsync(int id)
   {
      return await _studentRepository.GetByIdAsync(id);
   }

   public async Task<Student> GetByIdWithIncludeAsync(int id)
   {
      var student = _studentRepository.GetTableAsNoTracking()
                                      .Include(x => x.Department)
                                      .FirstOrDefault(x => x.StudID == id);

      return student;
   }

   public async Task<List<Student>> GetStudentsListAsync()
   {
      return await _studentRepository.GetStudentsListAsync();
   }

   public async Task<bool> IsNameExistsAsync(string name)
   {
      return await _studentRepository.GetTableAsNoTracking()
                                     .AnyAsync(x => x.Name == name);
   }

   public async Task<bool> IsNameExistsExcludeSelfAsync(string name, int id)
   {
      return await _studentRepository.GetTableAsNoTracking()
                                     .AnyAsync(x => x.Name == name && x.StudID != id);
   }
}
