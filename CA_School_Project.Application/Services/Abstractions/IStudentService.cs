using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Services.Abstractions;

public interface IStudentService
{

   Task<List<Student>> GetStudentsListAsync();
   Task<Student> GetByIdWithIncludeAsync(int id);
   Task<Student> GetByIdAsync(int id);
   Task<bool> AddAsync(Student student);
   Task<bool> EditAsync(Student student);
   Task<bool> DeleteAsync(Student student);
   Task<bool> IsNameExistsAsync(string name);
   Task<bool> IsNameExistsExcludeSelfAsync(string name, int id);

}
