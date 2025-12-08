using CA_School_Project.Domain.Entities;
using CA_School_Project.Infrastructure.Abstractionss;
using CA_School_Project.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
   private readonly ApplicationDbContext _dbContext;

   public StudentRepository(ApplicationDbContext dbContext)
   {
      this._dbContext = dbContext;
   }

   public async Task<List<Student>> GetStudentsListAsync()
   {
      return await _dbContext.Students.Include(x => x.Department)
                                      .ToListAsync();
   }

}
