using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Infrastructure.Repositories.Abstractionss;

public interface IStudentRepository : IGenericRepositoryAsync<Student>
{

   Task<List<Student>> GetStudentsListAsync();
 
}
