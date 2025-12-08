using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Infrastructure.Abstractionss;

public interface IStudentRepository
{

   Task<List<Student>> GetStudentsListAsync();
 
}
