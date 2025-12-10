using CA_School_Project.Domain.Entities;
using CA_School_Project.Infrastructure.Context;
using CA_School_Project.Infrastructure.Repositories.Abstractionss;
using Microsoft.EntityFrameworkCore;

namespace CA_School_Project.Infrastructure.Repositories;

public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
{
   private readonly DbSet<Instructor> _instructorDbSet;

   public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
   {
      this._instructorDbSet = dbContext.Set<Instructor>();
   }


}
