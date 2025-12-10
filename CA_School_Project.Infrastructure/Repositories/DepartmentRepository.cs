using CA_School_Project.Domain.Entities;
using CA_School_Project.Infrastructure.Context;
using CA_School_Project.Infrastructure.Repositories.Abstractionss;
using Microsoft.EntityFrameworkCore;

namespace CA_School_Project.Infrastructure.Repositories;

public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
{
   private readonly DbSet<Department> _departmentDbSet;

   public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
   {
      this._departmentDbSet = dbContext.Set<Department>();
   }


}
