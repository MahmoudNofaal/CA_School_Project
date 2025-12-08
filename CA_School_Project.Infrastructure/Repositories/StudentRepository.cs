using CA_School_Project.Domain.Entities;
using CA_School_Project.Infrastructure.Context;
using CA_School_Project.Infrastructure.Repositories.Abstractionss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Infrastructure.Repositories;

public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
{
   private readonly DbSet<Student> _studentsDbSet;

   public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
   {
      this._studentsDbSet = dbContext.Set<Student>();
   }

   public async Task<List<Student>> GetStudentsListAsync()
   {
      return await _studentsDbSet.Include(x => x.Department).ToListAsync();
   }

}
