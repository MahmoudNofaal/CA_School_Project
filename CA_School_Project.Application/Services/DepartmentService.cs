using CA_School_Project.Application.Services.Abstractions;
using CA_School_Project.Domain.Entities;
using CA_School_Project.Infrastructure.Repositories.Abstractionss;
using Microsoft.EntityFrameworkCore;

namespace CA_School_Project.Application.Services;

public class DepartmentService : IDepartmentService
{
   private readonly IDepartmentRepository _departmentRepository;

   public DepartmentService(IDepartmentRepository departmentRepository)
   {
      this._departmentRepository = departmentRepository;
   }

   

   public async Task<Department> GetByIdAsync(int id)
   {
      return await _departmentRepository.GetByIdAsync(id);
   }

   public async Task<Department> GetByIdWithIncludeAsync(int id)
   {
      var student = await _departmentRepository.GetTableAsNoTracking()
                                               //.Include(x => x.Students)
                                               .Include(x => x.DepartmentSubjects).ThenInclude(y => y.Subject)
                                               .Include(x => x.Instructors)
                                               .Include(x => x.Manager)
                                               .FirstOrDefaultAsync(x => x.Id == id);

      return student;
   }

   public async Task<bool> IsDepartmentIdExistsAsync(int id)
   {
      return await _departmentRepository.GetTableAsNoTracking().AnyAsync(x => x.Id == id);
   }
}

