using CA_School_Project.Domain.Entities;
using CA_School_Project.Infrastructure.Context;
using CA_School_Project.Infrastructure.Repositories.Abstractionss;
using Microsoft.EntityFrameworkCore;

namespace CA_School_Project.Infrastructure.Repositories;

public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
{
   private readonly DbSet<Subject> _subjectDbSet;

   public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
   {
      this._subjectDbSet = dbContext.Set<Subject>();
   }


}
