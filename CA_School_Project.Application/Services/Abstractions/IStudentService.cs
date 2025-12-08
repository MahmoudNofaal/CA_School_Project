using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Services.Abstractions;

public interface IStudentService
{

   public Task<List<Student>> GetStudentsListAsync();

}
